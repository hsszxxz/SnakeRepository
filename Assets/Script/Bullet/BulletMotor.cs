using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace bullet
{
    ///<summary>
    ///
    ///<summary>
    public class BulletMotor : MonoBehaviour
    {
        [HideInInspector]
        public float bulletSpeed;
        [HideInInspector]
        public Vector3 direction;
        private void Update()
        {
            BulletsMove();
            Vector3 viewPos = Camera.main.WorldToViewportPoint(transform.position);
            if (viewPos.x < -2 || viewPos.x > 2 || viewPos.y < -2 || viewPos.y > 2)
            {
                GameObjectPool.Instance.CollectObject(gameObject);
            }
        }
        private void BulletsMove()
        {
            transform.Translate(direction * bulletSpeed * Time.deltaTime);
        }
    }
}

