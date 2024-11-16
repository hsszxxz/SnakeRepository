using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace attack
{
    ///<summary>
    ///把扇形区域内的物品转换成另一种
    ///<summary>
    [Serializable]
    public class SectorTransforThingToAnother
    {
        [Tooltip("变之后的物体的预制体")]
        public GameObject anotherTingPrefab;
        private SectorArea area;
        private Transform self;
        [Tooltip("变之前物体的tag")]
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

