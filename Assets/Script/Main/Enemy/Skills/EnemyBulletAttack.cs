using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace enemy
{
    ///<summary>
    ///
    ///<summary>
    [RequireComponent(typeof(EnemyBase))]
    public class EnemyBulletAttack : BulletAttackMethod
    {
        private EnemyBase enemyBase;
        [Tooltip("隔玩家多少距离开始攻击")]
        public float distance;
        [Tooltip("隔多少时间攻击一次")]
        public float spaceTime;
        private float nowTime;
        private void Awake()
        {
            bulletTag = "enemybullet";
            layerName = "Default";
            nowTime = 0;
        }
        private void Start()
        {
            enemyBase = GetComponent<EnemyBase>();
        }
        private void Update()
        {
            nowTime += Time.deltaTime;
            if (Vector3.Distance(enemyBase.targetSneak.position, transform.position) <= distance)
            {
                if (nowTime > spaceTime)
                {
                    nowTime = 0;
                    Attack(enemyBase.targetSneak.position);
                }
            }
        }
    }
}

