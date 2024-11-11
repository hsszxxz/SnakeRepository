using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace move
{
    ///<summary>
    ///根据目标位置移动
    ///<summary>
    public interface ITargetMovable
    {
        public void MoveToTaget(Vector3 TargetPos);
        public void MoveToTaget(Vector2 Direction);
    }
}

