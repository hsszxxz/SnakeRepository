using enemy;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace sneak
{
    ///<summary>
    ///
    ///<summary>
    [RequireComponent(typeof(SneakSingleHeadControl))]
    public class SectorBackEnemy : MonoBehaviour
    {
        [Tooltip("���εĽǶ�")]
        public float angle = 60;
        [Tooltip("���εı߳�")]
        public float range = 4f;
        [Tooltip("�Ƶ��˵Ĳ�����")]
        public float backForce;
        [Tooltip("���ٶ��ٵ���")]
        public float addMoveForce;
        [Tooltip("���ٶ೤ʱ��")]
        public float addSpeedTime;
        public GameObject sectorArea;

        private SneakSingleHeadControl headControl;
        private void Start()
        {
            headControl = GetComponent<SneakSingleHeadControl>();
        }
        private void Update()
        {
            if (Input.GetKeyUp(KeyCode.E))
            {
                DetectObjectInSector(new List<string> { "enemy" ,"enemybullet"});
                sectorArea.SetActive(false);
            }
            if (Input.GetKey(KeyCode.E))
            {
                sectorArea.SetActive(true);
            }
        }
        private void DetectObjectInSector(List<string> tags)
        {
            Vector2 postion = transform.position;
            Vector2 direction = transform.up;

            Collider2D[] colliders = Physics2D.OverlapCircleAll(postion,range);

            foreach(var collider in colliders)
            {
                if (collider.gameObject == gameObject || !tags.Contains(collider.transform.tag) ) continue;

                Vector2 colliderPos = collider.transform.position;
                Vector2 toCollider = colliderPos - postion;
                float angleToCollider = Vector2.Angle(direction, toCollider);

                if (angleToCollider < angle/2 )
                {
                    if (collider.tag == "enemy")
                    {
                        IEnemyBackable backable = collider.gameObject.GetComponent<IEnemyBackable>();
                        if (backable != null)
                        {
                            backable.ShakeEnemyBack(transform, backForce);
                        }
                    }
                    else if (collider.tag =="enemybullet")
                    {
                        GameObjectPool.Instance.CollectObject(collider.gameObject);
                        GameObjectPool.Instance.CreateObject("food", Resources.Load("Prefabs/Food")as GameObject, collider.transform.position, Quaternion.identity);
                    }
                }
            }
        }
    }
}

