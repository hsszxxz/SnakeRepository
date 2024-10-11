using Pathfinding;
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
                }
            }
        }
        private int breakNumValue;
        [Tooltip("几秒之后会变成Enemy")]
        public float timeToEnemy;


        private float currentTime;
        private int resetBreakNum;
        private float resetTimeToEnemy;
        private void Start()
        {
            rigid = GetComponent<Rigidbody2D>();
            resetBreakNum = breakNum;
            resetTimeToEnemy = timeToEnemy;
        }
        private void Update()
        {
            currentTime += Time.deltaTime;
            if (currentTime > timeToEnemy)
            {
                GameObjectPool.Instance.CreateObject("enemy", Resources.Load("Prefabs/Enemy") as GameObject, transform.position, Quaternion.identity);
                currentTime = 0;
                GameObjectPool.Instance.CollectObject(gameObject);
            }
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

