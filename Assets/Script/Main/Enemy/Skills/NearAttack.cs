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
        [Tooltip("������ٿ�ʼ��ս")]
        public float distance;
        [Tooltip("�������빥��һ��")]
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

