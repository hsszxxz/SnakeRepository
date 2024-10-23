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
        private Transform attackTarge;
        private EnemyBase enemyBase;
        [Tooltip("����Ҷ��پ��뿪ʼ����")]
        public float distance;
        [Tooltip("������ʱ�乥��һ��")]
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
            attackTarge = enemyBase.FindTarget();
        }
        private void Update()
        {
            nowTime += Time.deltaTime;
            if (Vector3.Distance(attackTarge.position,transform.position)<=distance)
            {
                if (nowTime>spaceTime)
                {
                    nowTime = 0;
                    Attack(attackTarge.position);
                }
            }
        }
    }
}

