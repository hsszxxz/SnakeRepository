using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace attack
{
    ///<summary>
    ///��������ѡ���ڵ���ײ��
    ///<summary>
    [Serializable]
    public class SectorArea
    {
        [Tooltip("���εĽǶ�")]
        public float angle = 60;
        [Tooltip("���εı߳�")]
        public float range = 4f;

        private Transform self;
        public void Init(Transform Self)
        {
            self = Self;
        }
        public List<GameObject> DetectObjectInSector(List<string>backTags)
        {
            Vector2 postion = self.position;
            Vector2 direction = self.up;

            Collider2D[] colliders = Physics2D.OverlapCircleAll(postion, range);

            List<GameObject> result = new List<GameObject>();
            foreach (var collider in colliders)
            {
                if (collider.gameObject == self.gameObject || !backTags.Contains(collider.transform.tag)) continue;

                Vector2 colliderPos = collider.transform.position;
                Vector2 toCollider = colliderPos - postion;
                float angleToCollider = Vector2.Angle(direction, toCollider);

                if (angleToCollider < angle / 2)
                {
                    result.Add(collider.gameObject);
                }
            }
            return result;
        }
    }
}

