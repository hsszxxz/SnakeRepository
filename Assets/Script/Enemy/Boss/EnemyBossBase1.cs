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
                    GameObjectPool.Instance.CollectObject(gameObject);
                }
            }
        }
    }
}

