using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
namespace bullet
{
    ///<summary>
    ///��ͨ�ӵ��Ļ�������,����ת���ƶ�
    ///<summary>
    public class NormalBulletBase:BulletBase
    {
        public override void MoveToTaget(Vector2 Direction)
        {
            Vector3 direction = Direction;
            transform.position += direction * speed * Time.deltaTime;
        }
    }
}

