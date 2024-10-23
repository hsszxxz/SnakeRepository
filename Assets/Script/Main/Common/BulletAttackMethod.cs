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
    public Sprite bulletSprite;
    protected virtual void Attack(Vector3 targetPos)
    {
        Vector2 direction = Quaternion.Euler(20, 0, 0) * (targetPos - transform.position).normalized;
        GameObject bullet = GameObjectPool.Instance.CreateObject(bulletTag, Resources.Load("Prefabs/Bullet") as GameObject, transform.position, Quaternion.identity);
        bullet.transform.tag = bulletTag;
        bullet.GetComponent<SpriteRenderer>().sprite = bulletSprite;
        bullet.layer = LayerMask.NameToLayer(layerName);
        bullet.GetComponent<BulletMotor>().bulletSpeed = bulletSpeed;
        bullet.GetComponent<BulletMotor>().direction = direction;
    }
}

