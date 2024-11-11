using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace bullet
{
    ///<summary>
    ///弹幕子弹的基本属性，移动时会改变朝向
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

