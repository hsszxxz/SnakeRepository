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
        [Tooltip("�ӵ�������Щ����ʧ")]
        public List<string> tags = new List<string>();
        private void Update()
        {
            BulletsMove();
            Vector3 viewPos = Camera.main.WorldToViewportPoint(transform.position);
            if (viewPos.x < -1.5 || viewPos.x > 1.5 || viewPos.y < -1.5 || viewPos.y > 1.5)
            {
                GameObjectPool.Instance.CollectObject(gameObject);
            }
        }
        private void BulletsMove()
        {
            transform.Translate(direction * bulletSpeed * Time.deltaTime);
        }
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (tags.Contains(collision.transform.tag))
            {
                if (!(collision.transform.tag == "enemy" && transform.tag == "enemybullet"))
                {
                    GameObjectPool.Instance.CollectObject(gameObject);
                }
            }
        }
    }
}

