using sneak;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace enemy
{
    ///<summary>
    ///
    ///<summary>
    [RequireComponent(typeof(EnemyBase))]
    public class NearAttack : MonoBehaviour
    {
        [Tooltip("距离多少开始近战")]
        public float distance;
        [Tooltip("隔多少秒攻击一次")]
        public float spaceTime;
        private float currentTime;
        private EnemyBase enemyBase;
        private void Start ()
        {
            enemyBase = GetComponent<EnemyBase>();
            currentTime = 0;
        }
        private void Update ()
        {
            currentTime += Time.deltaTime;
            if (Vector2.Distance(transform.position, enemyBase.targetSneak.position) <= distance && currentTime >= spaceTime)
            {
                currentTime = 0;
                EventSystemCenter.Instance.EventTrigger("playerInjure");
            }
            
        }
    }
}

