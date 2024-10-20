using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace bullet
{
    ///<summary>
    ///
    ///<summary>
    public class BulletConfig : MonoSingleton<BulletConfig>
    {
        public BulletData[] datas;
        public Transform[] bossTransform;
        private List<Transform> shooters = new List<Transform>();
        private void Start()
        {
            for(int i =0; i< datas.Length;i++)
            {
                datas[i].ResetTempData(bossTransform[i]);
                Transform shooter = new GameObject(bossTransform[i].name + "shooter").transform;
                shooter.position = bossTransform[i].position;
                shooters.Add(shooter);
            }
        }
        private void Update()
        {
            for (int i = 0; i < datas.Length; i++)
            {
                Shoot(datas[i], shooters[i]);
            }
        }
        private void Shoot(BulletData data, Transform shooter)
        {
            if (Time.time - data.tempShootTime > data.cdTime)
            {
                data.tempShootTime = Time.time;
                int num = data.Count / 2;
                Quaternion q = Quaternion.Euler(0, 0, data.selfRotate);
                data.tempRotation *= q;
                for (int j = 0; j < data.Count; j++)
                {
                    GameObject bullet = GameObjectPool.Instance.CreateObject(shooter.name + "bullet", data.prafabs, data.P_Offset + shooter.position, Quaternion.Euler(data.R_Offset));
                    bullet.transform.tag = "enemybullet";
                    BulletMotor motor = bullet.GetComponent<BulletMotor>();
                    motor.bulletSpeed = data.speed;
                    motor.direction = bullet.transform.right;
                    bullet.transform.rotation = data.tempRotation* Quaternion.Euler(data.R_Offset);
                    if (data.Count %2 ==1)
                    {
                        bullet.transform.rotation = bullet.transform.rotation*Quaternion.Euler(0,0, data.angle * num);
                        bullet.transform.position = bullet.transform.position + bullet.transform.up*num*data.distance;
                    }
                    else
                    {
                        bullet.transform.rotation = bullet.transform.rotation * Quaternion.Euler(0, 0, data.angle / 2 + data.angle * (num - 1));
                        bullet.transform.position = bullet.transform.position + bullet.transform.up * ((num-1) * data.distance+ data.distance/2);
                    }
                    num--;
                }
            }
        }
    }
}

