using bullet;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace enemy
{
    ///<summary>
    ///
    ///<summary>
    public class EnemyBossBase1 : EnemyBase
    {
        [Tooltip("�ڶ���Ѫ֮��������ﵰ")]
        public int eggBlood;
        [Tooltip("�������ɵ��ı���")]
        public GenerateEnemyEgg generateEnemyEgg;
        private bool isEgg = true;
        [Tooltip("��Ҿ���boss���پ���ʱ������Ļ")]
        public float attackDetectDis;
        private BulletConfig bulletConfig;
        private bool isAttack = false;
        protected override void Start()
        {
            base.Start();
            bulletConfig =GetComponent<BulletConfig>();
        }
        public override void EnemyInit()
        {
            base.EnemyInit();
            isEgg = true;
            bulletConfig.enabled = false;
            isAttack = false;
        }
        private void Update()
        {
            if ( Vector2.Distance(transform.position,FindTarget().position)<=attackDetectDis &&!isAttack)
            {
                bulletConfig.enabled = true;
                isAttack = true;
            }
        }
        protected override void OnCollisionEnter2D(Collision2D collision)
        {
            if(collision.transform.CompareTag("playerbullet"))
            {
                blood -= 1;
                if (blood <= eggBlood && isEgg)
                {
                    generateEnemyEgg.Excute(transform.position);
                    isEgg = false;
                }
                if (blood <= 0)
                {
                    EnemyManager.Instance.bossDic.Remove("boss1");
                    EnemyManager.Instance.enemyDebate[0] = true;
                    Destroy(gameObject);
                }
            }
        }
    }
}

