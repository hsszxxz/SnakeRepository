using move;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;
namespace bullet
{
    ///<summary>
    ///�ӵ����Ը���
    ///<summary>
    public class BulletBase:MonoBehaviour,ITargetMovable
    {
        [HideInInspector]
        public float speed;
        
        [Tooltip("�ӵ�������Щ����ʧ")]
        public List<string> tags = new List<string>();
        
        public virtual void MoveToTaget(Vector2 Direction) { }
        
        public void MoveToTaget(Vector3 TargetPos)
        {
            Vector2 direction = Quaternion.Euler(20, 0, 0) * (TargetPos - transform.position).normalized;
            MoveToTaget(direction);
        }
    }
}

