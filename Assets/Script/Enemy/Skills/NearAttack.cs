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
        private Transform target;
        private void Start ()
        {
            target = GetComponent<EnemyBase>().FindTarget();
        }
        private void Update ()
        {
            if (Vector2.Distance(transform.position,target.position)<=distance)
            {
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
    }
}

