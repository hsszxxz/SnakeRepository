using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace move
{
    ///<summary>
    ///����ͨ�������豸���Ƶ��ƶ�����
    ///<summary>
    public interface  IControlMovable
    {
        public void MoveToRight();
        public void MoveToLeft();
        public void MoveToForward();
        public void MoveToBackward();

    }
}

