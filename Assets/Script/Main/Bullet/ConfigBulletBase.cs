using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace bullet
{
    ///<summary>
    ///��Ļ�ӵ��Ļ������ԣ��ƶ�ʱ��ı䳯��
    ///<summary>
    public class ConfigBulletBase: BulletBase
    {
        public override void MoveToTaget(Vector2 Direction)
        {
            Vector3 direction = Direction;
            transform.Translate(direction * speed * Time.deltaTime);
        }
    }
}

