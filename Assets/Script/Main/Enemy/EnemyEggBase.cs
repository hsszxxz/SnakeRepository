using Pathfinding;
using sneak;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace enemy
{
    ///<summary>
    ///
    ///<summary>
    public class EnemyEggBase : MonoBehaviour, IEnemyBackable,IResetable
    {
        private Rigidbody2D rigid;
        [Tooltip("��Ҫ���򼸴βŻ���ʧ")]
        public int breakNum
        {
            get
            {
                return breakNumValue;
            }
            set
            {
                breakNumValue = value;
                if (value <= 0)
                {
                    GameObjectPool.Instance.CollectObject(gameObject);
                }
            }
        }
        [Tooltip("��Ҫ���򼸴βŻ���ʧ")]
        public int BreakNum;
        private int breakNumValue;
        [Tooltip("����֮�����Enemy")]
        public float timeToEnemy;
        [Tooltip("������Ҷ��پ��뿪ʼ��ʱ")]
        public float distance;

        private float currentTime;
        private int resetBreakNum;
        private float resetTimeToEnemy;
        private void Start()
        {
            rigid = GetComponent<Rigidbody2D>();
            resetBreakNum = breakNum;
            resetTimeToEnemy = timeToEnemy;
            breakNum = BreakNum;
        }
        private void Update()
        {
            if (Vector2.Distance(FindTarget().position,transform.position) <= distance)
            {
                currentTime += Time.deltaTime;
            }
            if (currentTime > timeToEnemy)
            {
                GameObjectPool.Instance.CreateObject("enemy", Resources.Load("Prefabs/Enemy") as GameObject, transform.position, Quaternion.identity);
                currentTime = 0;
                GameObjectPool.Instance.CollectObject(gameObject);
            }
        }
        private Transform FindTarget()
        {
            Transform head1Trans = SneakManager.Instance.head1.transform;
            Transform head2Trans = SneakManager.Instance.head2.transform;
            float distance1 = Vector2.Distance(transform.position, head1Trans.position);
            float distance2 = Vector2.Distance(transform.position, head2Trans.position);
            return (distance1 > distance2) ? head2Trans : head1Trans;
        }
        public void ShakeEnemyBack(Transform shakeFrom, float backForce)
        {
            Vector3 dir = (transform.position - shakeFrom.position).normalized;
            rigid.AddForce(dir * backForce, ForceMode2D.Impulse);
            breakNum--;
        }

        public void OnReset()
        {
            breakNum = resetBreakNum;
            timeToEnemy = resetTimeToEnemy;
            currentTime = 0;
        }
    }
}

