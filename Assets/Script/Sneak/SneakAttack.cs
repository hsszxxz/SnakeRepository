using bullet;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace sneak
{
    ///<summary>
    ///
    ///<summary>
    public class SneakAttack : MonoBehaviour
    {
        public float bulletSpeed;
        private void Update()
        { 
            if (Input.GetMouseButtonUp(1))
            {
                if (Time.timeScale != 0)
                {
                    if (SneakManager.Instance.bodies.Count <= 2)
                        Debug.Log("No bullet");
                    else
                    {
                        SneakManager.Instance.DeletSneakBody(SneakManager.Instance.bodies[2]);
                        Attack();
                    }
                }
            }
        }
        private void Attack()
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 selfPos = transform.position;
            Vector2 direction =Quaternion.Euler(20,0,0)*(mousePos- selfPos).normalized;
            GameObject bullet = GameObjectPool.Instance.CreateObject("bullet",Resources.Load("Prefabs/Bullet") as GameObject,transform.position,Quaternion.identity);
            bullet.transform.tag ="bullet";
            bullet.GetComponent<BulletMotor>().bulletSpeed = bulletSpeed;
            bullet.GetComponent<BulletMotor>().direction = direction;
        }
        private void BulletsMove(GameObject bullet , Vector3 direction)
        {
            bullet.transform.Translate(direction*bulletSpeed*Time.deltaTime);
        }
    }
}

