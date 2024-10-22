using bullet;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace sneak
{
    ///<summary>
    ///
    ///<summary>
    public class SneakAttack : BulletAttackMethod
    {
        private void Awake()
        {
            bulletTag = "playerbullet";
            layerName = "PlayerBullet";
        }
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
                        Attack(Camera.main.ScreenToWorldPoint(Input.mousePosition));
                    }
                }
            }
        }
    }
}

