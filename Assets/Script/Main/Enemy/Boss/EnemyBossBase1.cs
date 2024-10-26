using bullet;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace enemy
{
    ///<summary>
    ///
    ///<summary>
    public class EnemyBossBase1 : EnemyBoosBase
    {
        [Tooltip("�ڶ���Ѫ֮��������ﵰ")]
        public int eggBlood;
        [Tooltip("�������ɵ��ı���")]
        public GenerateEnemyEgg generateEnemyEgg;
        private bool isEgg = true;
        private GameObject key;
        protected override void Start()
        {
            key = GameObject.Find("8Կ��");
            key.SetActive(false);
            enemyInjureName = "enemyInjure1";
            base.Start();
        }
        public override void EnemyInit()
        {
            base.EnemyInit();
            isEgg = true;
        }
        protected override void GotInjured()
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
                bloodUIWindow.ShutAndOpen(false);
                key.gameObject.SetActive(true);
                key.transform.position = transform.position;
                Destroy(gameObject);
            }
        }
    }
}

