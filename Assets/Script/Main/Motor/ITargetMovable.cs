using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace move
{
    ///<summary>
    ///����Ŀ��λ���ƶ�
    ///<summary>
    public interface ITargetMovable
    {
        public void MoveToTaget(Vector3 TargetPos);
        public void MoveToTaget(Vector2 Direction);
    }
}

