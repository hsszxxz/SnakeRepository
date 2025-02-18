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
    public class EnemyEggBase : MonoBehaviour, IEnemyBackable,IInitable
    {
        private Rigidbody2D rigid;
        [Tooltip("需要波打几次才会消失")]
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
                    GameObjectPool.Instance.CreateObject("food",Resources.Load("Prefabs/Food") as GameObject, transform.position, Quaternion.identity);
                }
            }
        }
        [Tooltip("需要波打几次才会消失")]
        public int BreakNum;
        private int breakNumValue;
        [Tooltip("几秒之后会变成Enemy")]
        public float timeToEnemy;
        [Tooltip("几秒之后裂")]
        public float timeToBreak;
        [Tooltip("距离玩家多少距离开始计时")]
        public float distance;
        public Sprite breakEgg;

        private float currentTime;
        private int resetBreakNum;
        private float resetTimeToEnemy;
        private bool isBreak;
        private void Start()
        {
            rigid = GetComponent<Rigidbody2D>();
            resetBreakNum = breakNum;
            resetTimeToEnemy = timeToEnemy;
            breakNum = BreakNum;
            isBreak = false;
        }
        private void Update()
        {
            if (Vector2.Distance(FindTarget().position,transform.position) <= distance)
            {
                currentTime += Time.deltaTime;
            }
            if (currentTime > timeToBreak&&!isBreak)
            {
                isBreak = true;
                transform.GetComponent<SpriteRenderer>().sprite = breakEgg;
            }
            if (currentTime > timeToEnemy)
            {
                GameObjectPool.Instance.CreateObject("enemy", Resources.Load("Prefabs/Enemy") as GameObject, transform.position, Quaternion.identity);
                currentTime = 0;
                Destroy(gameObject);
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


        public void enemyInit()
        {
            breakNum = resetBreakNum;
            timeToEnemy = resetTimeToEnemy;
            currentTime = 0;
        }
    }
}

