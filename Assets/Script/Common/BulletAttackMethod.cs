using bullet;
using sneak;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class BulletAttackMethod : MonoBehaviour
{
    public float bulletSpeed;
    protected string bulletTag;
    protected string layerName;
    protected virtual void Attack(Vector3 targetPos)
    {
        Vector2 direction = Quaternion.Euler(20, 0, 0) * (targetPos - transform.position).normalized;
        GameObject bullet = GameObjectPool.Instance.CreateObject(bulletTag, Resources.Load("Prefabs/Bullet") as GameObject, transform.position, Quaternion.identity);
        bullet.transform.tag = bulletTag;
        bullet.layer = LayerMask.NameToLayer(layerName);
        bullet.GetComponent<BulletMotor>().bulletSpeed = bulletSpeed;
        bullet.GetComponent<BulletMotor>().direction = direction;
    }
}

