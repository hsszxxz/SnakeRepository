using move;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace bullet
{
    ///<summary>
    ///×Óµ¯¿ØÖÆ½Å±¾
    ///<summary>
    [RequireComponent(typeof(BulletBase))]
    public class BulletControl : MonoBehaviour
    {        
        [HideInInspector]
        public float bulletSpeed
        {
            get
            {
                return bulletSpeedValue;
            }
            set
            {
                bulletSpeedValue = value;
                bulletBase.speed = value;
            }
        }
        private float bulletSpeedValue;
        [HideInInspector]
        public Vector2 direction;

        private BulletBase bulletBase;
        private void Awake()
        {
            bulletBase = GetComponent<BulletBase>();
        }
        private void Update()
        {
            if (direction != Vector2.zero)
            {
                bulletBase.GetComponent<ITargetMovable>().MoveToTaget(direction);
            }
            Vector3 viewPos = Camera.main.WorldToViewportPoint(transform.position);
            if (viewPos.x < -1.5 || viewPos.x > 1.5 || viewPos.y < -1.5 || viewPos.y > 1.5)
            {
                GameObjectPool.Instance.CollectObject(gameObject);
            }
        }
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (bulletBase.tags.Contains(collision.transform.tag))
            {
                GameObjectPool.Instance.CollectObject(gameObject);
            }
        }
    }
}

