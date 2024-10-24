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
        private Transform target;
        private void Start ()
        {
            target = GetComponent<EnemyBase>().FindTarget();
            currentTime = 0;
        }
        private void Update ()
        {
            currentTime += Time.deltaTime;
            if (target != null)
            {
                if (Vector2.Distance(transform.position, target.position) <= distance && currentTime >= spaceTime)
                {
                    currentTime = 0;
                    if (SneakManager.Instance.bodies.Count >= 3)
                    {
                        SneakManager.Instance.DeletSneakBody(SneakManager.Instance.bodies[2]);
                    }
                    else
                    {
                        Debug.LogError("������");
                    }
                }
            }
            else
            {
                target = GetComponent<EnemyBase>().FindTarget();
            }
        }
    }
}

