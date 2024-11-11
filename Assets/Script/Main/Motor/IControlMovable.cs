using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace move
{
    ///<summary>
    ///可以通过输入设备控制的移动方法
    ///<summary>
    public interface  IControlMovable
    {
        public void MoveToRight();
        public void MoveToLeft();
        public void MoveToForward();
        public void MoveToBackward();

    }
}

