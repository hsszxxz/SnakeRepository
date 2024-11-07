using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace bullet
{
    ///<summary>
    ///子弹控制脚本
    ///<summary>
    public class BulletControl : MonoBehaviour
    {
        [Tooltip("是否是弹幕子弹")]
        public bool isBulletConfig;
        
        [HideInInspector]
        public float bulletSpeed;
        [HideInInspector]
        public Vector3 direction;
        [Tooltip("子弹碰到哪些会消失")]
        public List<string> tags = new List<string>();
        private void Update()
        {
            if (isBulletConfig)
            {
                BulletsConfigMove();
            }
            else
            {
                BulletsMove();
            }
            Vector3 viewPos = Camera.main.WorldToViewportPoint(transform.position);
            if (viewPos.x < -1.5 || viewPos.x > 1.5 || viewPos.y < -1.5 || viewPos.y > 1.5)
            {
                GameObjectPool.Instance.CollectObject(gameObject);
            }
        }
        private void BulletsMove()
        {
            transform.position += direction * bulletSpeed * Time.deltaTime;
        }
        private void BulletsConfigMove()
        {
            transform.Translate(direction * bulletSpeed * Time.deltaTime);
        }
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (tags.Contains(collision.transform.tag))
            {
                GameObjectPool.Instance.CollectObject(gameObject);
            }
        }
    }
}

