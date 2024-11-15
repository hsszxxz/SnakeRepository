using bullet;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;
namespace enemy
{
    ///<summary>
    ///
    ///<summary>
    public class EnemyBoss1Base:EnemyBase
    {
        protected BloodUIWindow bloodUIWindow;
        public Sprite bloodBackSprite;

        [Tooltip("�ڶ���Ѫ֮��������ﵰ")]
        public int eggBlood;
        [Tooltip("�������ɵ��ı���")]
        public GenerateEnemyEgg generateEnemyEgg;
        private bool isEgg = true;
        private GameObject key;
        private BulletConfig bulletConfig;

        [Tooltip("������ٿ�ʼ��ս")]
        public float distance;
        [Tooltip("�������빥��һ��")]
        public float spaceTime;
        private float currentTime;

        private void EnterAttackMethod()
        {
            bulletConfig.enabled = true;
        }
        protected override void Start()
        {
            base.Start();
            key = GameObject.Find("8Կ��");
            key.SetActive(false);
        }
        public override void enemyInit()
        {
            base.enemyInit();
            if (key!=null)
            {
                key.SetActive(false);
            }
            bulletConfig = GetComponent<BulletConfig>();
            bulletConfig.enabled = false;
            isEgg = true;
        }
        private void OnDeath()
        {
            EnemyManager.Instance.bossDic.Remove("boss1");
            EnemyManager.Instance.enemyDebate[0] = true;
            key.gameObject.SetActive(true);
            key.transform.position = transform.position;
        }
        private void GotInjured(int currentBlood)
        {
            if (currentBlood <= eggBlood && isEgg)
            {
                generateEnemyEgg.Excute(transform.position);
                isEgg = false;
            }
        }

        public override void Attack()
        {
            bloodUIWindow.BloodLineChange(blood, maxBlood);
            currentTime += Time.deltaTime;
            if (Vector2.Distance(transform.position, targetSneak.position) <= distance && currentTime >= spaceTime)
            {
                currentTime = 0;
                EventSystemCenter.Instance.EventTrigger("playerInjure");
            }
        }

        public override void GetInjured()
        {
            if (blood <= eggBlood && isEgg)
            {
                generateEnemyEgg.Excute(transform.position);
                isEgg = false;
            }
        }

        public override void Dead()
        {
            EnemyManager.Instance.bossDic.Remove("boss1");
            EnemyManager.Instance.enemyDebate[0] = true;
            key.gameObject.SetActive(true);
            key.transform.position = transform.position;
        }

        public override void Release()
        {
        }

        public override void OnEnterAttack()
        {
            bulletConfig.enabled = true;
            FungusController.Instance.StartBlock("Boss1ǰ");
            bloodUIWindow.ShutAndOpen(true);
            bloodUIWindow.bloodBack.sprite = bloodBackSprite;
        }
    }
}

