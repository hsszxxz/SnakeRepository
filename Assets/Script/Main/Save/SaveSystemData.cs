using save;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace save
{
    ///<summary>
    ///
    ///<summary>
    /// <summary>
    /// �浵ϵͳ������
    /// </summary>
    [Serializable]
    public class SaveSystemData
    {
        // ��ǰ�Ĵ浵ID
        public int currID = 0;
        // ���д浵���б�
        public List<SavePoint> saveItemList = new List<SavePoint>();
    }

}

