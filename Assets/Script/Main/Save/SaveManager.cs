using sneak;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace save
{
    ///<summary>
    ///
    ///<summary>
    public class SaveManager : MonoSingleton<SaveManager>
    {
        [Tooltip("存档点")]
        public List<Transform> SavePoint = new List<Transform>();
        [Tooltip("存档点对应的提示")]
        public List<GameObject> tiShiPanels = new List<GameObject>();
        //[HideInInspector]
        public int currentSaveIndex;
        [HideInInspector]
        public List<int> allSaveIndex = new List<int>();
        private float distance = 5;
        public override void Init()
        {
            currentSaveIndex = SaveSystem.LoadIndex();
        }
        private void Update()
        {
            for (int i =0; i<SavePoint.Count;i++)
            {
                if (Vector2.Distance(FindTarget().position, SavePoint[i].position)<=distance)
                {
                    tiShiPanels[i].SetActive(true);
                    if (Input.GetKeyDown(KeyCode.Space))
                    {
                        SaveSystem.SaveAll(currentSaveIndex);
                    }
                }
                else
                {
                    tiShiPanels[i].SetActive(false);
                }
            }
        }
        private Transform FindTarget()
        {
            Transform head1Trans = SneakManager.Instance.head1.transform;
            Transform head2Trans = SneakManager.Instance.head2.transform;
            if (head1Trans == null || head2Trans == null)
                return null;
            float distance1 = Vector2.Distance(transform.position, head1Trans.position);
            float distance2 = Vector2.Distance(transform.position, head2Trans.position);
            return (distance1 > distance2) ? head2Trans : head1Trans;
        }
    }
}

