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
        private BloodUIWindow bloodUIWindow;
        public Sprite bloodBackSprite;

        [Tooltip("在多少血之后产生怪物蛋")]
        public int eggBlood;
        [Tooltip("关于生成蛋的变量")]
        public GenerateEnemyEgg generateEnemyEgg;
        private bool isEgg = true;
        private GameObject key;
        private BulletConfig bulletConfig;

        [Tooltip("距离多少开始近战")]
        public float distance;
        [Tooltip("隔多少秒攻击一次")]
        public float spaceTime;
        private float currentTime;


        protected override void Start()
        {
            base.Start();
            key = GameObject.Find("8钥匙");
            key.SetActive(false);
            bloodUIWindow = UIManager.Instance.GetUIWindow<BloodUIWindow>();
            enemyInit();
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
            blood -= 1;
            if (blood <= eggBlood && isEgg)
            {
                generateEnemyEgg.Excute(transform.position);
                isEgg = false;
            }
            StartCoroutine(LightAgain());
        }

        public override void Dead()
        {
            EnemyManager.Instance.bossDic.Remove("boss1");
            EnemyManager.Instance.enemyDebate[0] = true;
            key.gameObject.SetActive(true);
            key.transform.position = transform.position;
            bloodUIWindow.ShutAndOpen(false);
        }

        public override void Release()
        {
        }

        public override void OnEnterAttack()
        {
            bulletConfig.enabled = true;
            FungusController.Instance.StartBlock("Boss1前");
            bloodUIWindow.ShutAndOpen(true);
            bloodUIWindow.bloodBack.sprite = bloodBackSprite;
        }
    }
}

