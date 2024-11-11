using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace attack
{
    ///<summary>
    ///�����������ڵ���Ʒת������һ��
    ///<summary>
    [Serializable]
    public class SectorTransforThingToAnother
    {
        [Tooltip("��֮��������Ԥ����")]
        public GameObject anotherTingPrefab;
        private SectorArea area;
        private Transform self;
        [Tooltip("��֮ǰ�����tag")]
        public List<string> thingTags;
        public void Init(Transform Self, SectorArea Area)
        {
            self = Self;
            area = Area;
        }
        public void Release()
        {
            List<GameObject> target = area.DetectObjectInSector(thingTags);
            foreach (GameObject obj in target)
            {
                GameObjectPool.Instance.CollectObject(obj);
                GameObjectPool.Instance.CreateObject("food", anotherTingPrefab, obj.transform.position, Quaternion.identity);
            }
        }
    }
}

