using move;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;
namespace bullet
{
    ///<summary>
    ///子弹属性父类
    ///<summary>
    public class BulletBase:MonoBehaviour,ITargetMovable
    {
        [HideInInspector]
        public float speed;
        
        [Tooltip("子弹碰到哪些会消失")]
        public List<string> tags = new List<string>();
        
        public virtual void MoveToTaget(Vector2 Direction) { }
        
        public void MoveToTaget(Vector3 TargetPos)
        {
            Vector2 direction = Quaternion.Euler(20, 0, 0) * (TargetPos - transform.position).normalized;
            MoveToTaget(direction);
        }
    }
}

