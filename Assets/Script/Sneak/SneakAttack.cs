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
            if (Input.GetMouseButtonDown(0))
            {
                if (SneakManager.Instance.bodies.Count<= 2)
                    Debug.Log("No bullet");
                else
                {
                    SneakManager.Instance.DeletSneakBody(SneakManager.Instance.bodies[2]);
                    Attack();
                }
            }
        }
        private void Attack()
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 direction = (transform.position - mousePos).normalized;
            Vector3 dir = new Vector3(-direction.x,-direction.y, 0);
            GameObject bullet = Instantiate(Resources.Load("Prefabs/Bullet") as GameObject);
            bullet.transform.tag ="bullet";
            bullet.transform.position = transform.position;
            bullet.GetComponent<BulletMotor>().bulletSpeed = bulletSpeed;
            bullet.GetComponent<BulletMotor>().direction = dir;
        }
        private void BulletsMove(GameObject bullet , Vector3 direction)
        {
            bullet.transform.Translate(direction*bulletSpeed*Time.deltaTime);
        }
    }
}

