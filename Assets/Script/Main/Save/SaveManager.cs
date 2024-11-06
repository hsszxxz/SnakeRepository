using sneak;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.U2D;
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
        private float distance = 5;
        [HideInInspector]
        public int currentSaveIndex;
        [HideInInspector]
        public bool isNewSave;
        public GameObject items;
        private Dictionary<int , GameObject> itemGo = new Dictionary<int , GameObject>();
        public override void Init()
        {
            ShowSaveItemList();
        }

        private void ShowSaveItemList()
        {
            List<SavePoint> itemRecorder = SaveSystemManager.Instance.GetAllSaveItemByUpdateTime();
            if (itemRecorder != null)
            {
                for (int i = 0; i < itemRecorder.Count; i++)
                {
                    GameObject saveItem = Instantiate(Resources.Load("Prefabs/SaveItem") as GameObject, items.transform);
                    saveItem.transform.GetComponent<SaveItem>().ItemInit(Resources.Load<Sprite>("ScreenShot/"), itemRecorder[i].LastSaveTime.ToString(), itemRecorder[i].saveID);
                    itemGo.Add(itemRecorder[i].saveID, saveItem);
                }
            }
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
                        string pictureName = DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss");
                        ScreenCapture.CaptureScreenshot("Assets/Resources/ScreenShot/" + pictureName + ".png");
                        if (!isNewSave)
                        {
                            Destroy(itemGo[currentSaveIndex]);
                            itemGo.Remove(currentSaveIndex);
                        }
                        GameObject saveItem = Instantiate(Resources.Load("Prefabs/SaveItem") as GameObject, items.transform);
                        Debug.Log(saveItem);
                        saveItem.transform.GetComponent<SaveItem>().ItemInit(Resources.Load<Sprite>("ScreenShot/" + pictureName), pictureName, currentSaveIndex);
                        itemGo.Add(currentSaveIndex,saveItem);
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

