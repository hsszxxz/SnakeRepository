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
    public class EnemyBossBase2 : EnemyBoosBase
    {
        [Tooltip("还剩多少血时进入二阶段")]
        public float secondBlood;
        [Tooltip("二阶段近战攻击距离")]
        public float secondDis;
        [Tooltip("二阶段攻击间隔")]
        public float secondSpace;
        private bool isSecond = true;
        protected override void Start()
        {
            enemyInjureName = "enemyInjure2";
            base.Start();
            GetComponent<FollowPlayer>().PathFindingComponentControl(false);
        }
        public override void EnemyInit()
        {
            base.EnemyInit();
            isSecond = true;
            boss2Detect.SetActive(true);
            GetComponent<FollowPlayer>().PathFindingComponentControl(false);
        }
        protected override void GotInjured()
        {
            blood -= 1;
            if (blood <= 0)
            {
                EnemyManager.Instance.bossDic.Remove("boss2");
                EnemyManager.Instance.enemyDebate[1] = true;
                bloodUIWindow.ShutAndOpen(false);
                FungusController.Instance.StartBlock("Boss2后");
                Destroy(gameObject);
            }
            else if (blood <= secondBlood && isSecond)
            {
                isSecond = false;
                GetComponent<NearAttack>().isBoss2First = false;
                boss2Detect.SetActive(false);
                GetComponent<FollowPlayer>().PathFindingComponentControl(false);
                GetComponent<NearAttack>().distance = secondDis;
                GetComponent<NearAttack>().spaceTime = secondSpace;
                bulletConfig.enabled = true;
            }
        }
    }
}

