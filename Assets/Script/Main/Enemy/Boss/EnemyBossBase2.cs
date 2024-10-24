using bullet;
using enemy;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace enemy
{
    ///<summary>
    ///
    ///<summary>
    public class EnemyBossBase2 : EnemyBase
    {
        [Tooltip("��ʣ����Ѫʱ������׶�")]
        public float secondBlood;
        [Tooltip("���׶ν�ս��������")]
        public float secondDis;
        [Tooltip("���׶ι������")]
        public float secondSpace;
        private bool isSecond = true;
        [Tooltip("��Ҿ���boss���پ���ʱ������Ļ")]
        public float attackDetectDis;
        private BulletConfig bulletConfig;
        private bool isAttack = false;
        protected override void Start()
        {
            base.Start();
            bulletConfig = GetComponent<BulletConfig>();
        }
        public override void EnemyInit()
        {
            base.EnemyInit();
            isSecond = true;
            bulletConfig.enabled = false;
            isAttack = false;
        }
        private void Update()
        {
            if (Vector2.Distance(transform.position, FindTarget().position) <= attackDetectDis && !isAttack)
            {
                bulletConfig.enabled = true;
                isAttack = true;
            }
        }
        protected override void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.transform.CompareTag("playerbullet"))
            {
                blood -= 1;
                if (blood <= 0)
                {
                    EnemyManager.Instance.bossDic.Remove("boss2");
                    EnemyManager.Instance.enemyDebate[1] = true;
                    Destroy(gameObject);
                }
                else if (blood <=secondBlood && isSecond)
                {
                    isSecond = false;
                    GetComponent<FollowPlayer>().PathFindingComponentControl(false);
                    GetComponent<NearAttack>().distance = secondDis;
                    GetComponent<NearAttack>().spaceTime = secondSpace;
                }
            }
        }
    }
}

