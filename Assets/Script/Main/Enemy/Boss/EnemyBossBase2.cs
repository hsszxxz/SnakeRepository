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
        [Tooltip("还剩多少血时进入二阶段")]
        public float secondBlood;
        [Tooltip("二阶段近战攻击距离")]
        public float secondDis;
        [Tooltip("二阶段攻击间隔")]
        public float secondSpace;
        private bool isSecond = true;
        [Tooltip("玩家距离boss多少距离时开启弹幕")]
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
            if (Vector2.Distance(transform.position, targetSneak.position) <= attackDetectDis && !isAttack)
            {
                bulletConfig.enabled = true;
                isAttack = true;
            }
        }
        protected override void GotInjured()
        {
            blood -= 1;
            if (blood <= 0)
            {
                EnemyManager.Instance.bossDic.Remove("boss2");
                EnemyManager.Instance.enemyDebate[1] = true;
                Destroy(gameObject);
            }
            else if (blood <= secondBlood && isSecond)
            {
                isSecond = false;
                GetComponent<FollowPlayer>().PathFindingComponentControl(false);
                GetComponent<NearAttack>().distance = secondDis;
                GetComponent<NearAttack>().spaceTime = secondSpace;
            }
        }
    }
}

