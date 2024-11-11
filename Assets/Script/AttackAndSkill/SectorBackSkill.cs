using enemy;
using sneak;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace attack
{
    ///<summary>
    ///���ɻ�����Ʒ���˷���
    ///<summary>
    [Serializable]
    public class SectorBackSkill
    {
        [Tooltip("������")]
        public float backForce;
        private Transform self;
        private SectorArea sectorArea;
        public List<string> backEnemyTags;
        public void Init(Transform Self, SectorArea Area)
        {
            self = Self;
            sectorArea = Area;
        }

        public void Release()
        {
            List<GameObject> backList = sectorArea.DetectObjectInSector(backEnemyTags);
            foreach (var back in backList)
            {
                IEnemyBackable backable = back.GetComponent<IEnemyBackable>();
                if (backable != null)
                {
                    backable.ShakeEnemyBack(self, backForce);
                }
            }
        }
    }
}

