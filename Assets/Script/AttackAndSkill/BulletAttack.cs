using bullet;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace attack
{
    ///<summary>
    ///使用子弹进行攻击
    ///<summary>
    [Serializable]
    public class BulletAttack
    {
        public void Init(Transform Self)
        {
            self = Self;
        }
        public float bulletSpeed;
        public GameObject bulletPrefab;
        [HideInInspector]
        public Vector3 targetPos;
        private  Transform self;
        public void Attack()
        {
            Vector2 direction = Quaternion.Euler(20, 0, 0) * (targetPos - self.position).normalized;
            float angle = Vector2.Angle(Vector2.up, direction);
            if (targetPos.x > self.position.x)
            {
                angle = -angle;
            }
            GameObject bullet = GameObjectPool.Instance.CreateObject(bulletPrefab.name, bulletPrefab, self.position, Quaternion.Euler(0, 0, angle));
            bullet.GetComponent<BulletControl>().bulletSpeed = bulletSpeed;
            bullet.GetComponent<BulletControl>().direction = direction; 
        }
    }
}

