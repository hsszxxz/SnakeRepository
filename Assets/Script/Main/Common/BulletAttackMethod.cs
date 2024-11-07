using bullet;
using sneak;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class BulletAttackMethod : MonoBehaviour
{
    public float bulletSpeed;
    public GameObject bulletPrefab;
    protected virtual void Attack(Vector3 targetPos)
    {
        Vector2 direction = Quaternion.Euler(20, 0, 0) * (targetPos - transform.position).normalized;
        float angle = Vector2.Angle(Vector2.up,direction);
        if (targetPos.x> transform.position.x)
        {
            angle = -angle;
        }
        GameObject bullet = GameObjectPool.Instance.CreateObject(bulletPrefab.name, bulletPrefab, transform.position,Quaternion.Euler(0,0,angle));
        bullet.GetComponent<BulletControl>().bulletSpeed = bulletSpeed;
        bullet.GetComponent<BulletControl>().direction = direction;
    }
}

