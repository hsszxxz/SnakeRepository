using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace enemy
{
    ///<summary>
    ///
    ///<summary>
    public class EnemyBossBase1 : MonoBehaviour
    {
        [Tooltip("���Ѫ��")]
        public int maxBlood;
        [Tooltip("�ڶ���Ѫ֮��������ﵰ")]
        public int eggBlood;
        [HideInInspector]
        public int blood;
        public GenerateEnemyEgg generateEnemyEgg;
        private bool isEgg = true;
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if(collision.transform.CompareTag("playerbullet"))
            {
                blood -= 1;
                if (blood <= eggBlood && isEgg)
                {
                    generateEnemyEgg.Excute(transform.position);
                    isEgg = false;
                }
            }
        }
    }
}

