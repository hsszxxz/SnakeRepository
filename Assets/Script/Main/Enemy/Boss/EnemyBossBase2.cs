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
        [Tooltip("��ʣ����Ѫʱ������׶�")]
        public float secondBlood;
        [Tooltip("���׶ν�ս��������")]
        public float secondDis;
        [Tooltip("���׶ι������")]
        public float secondSpace;
        private bool isSecond = true;
        protected override void Start()
        {
            enemyInjureName = "enemyInjure2";
            base.Start();
        }
        public override void EnemyInit()
        {
            base.EnemyInit();
            isSecond = true;
        }
        protected override void GotInjured()
        {
            blood -= 1;
            if (blood <= 0)
            {
                EnemyManager.Instance.bossDic.Remove("boss2");
                EnemyManager.Instance.enemyDebate[1] = true;
                bloodUIWindow.ShutAndOpen(false);
                Destroy(gameObject);
            }
            else if (blood <= secondBlood && isSecond)
            {
                isSecond = false;
                GetComponent<FollowPlayer>().PathFindingComponentControl(false);
                GetComponent<NearAttack>().distance = secondDis;
                GetComponent<NearAttack>().spaceTime = secondSpace;
                bulletConfig.enabled = true;
            }
        }
    }
}

