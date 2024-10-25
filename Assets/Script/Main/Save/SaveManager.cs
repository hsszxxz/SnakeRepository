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
        [HideInInspector]
        public int currentSaveIndex;
        [HideInInspector]
        public Dictionary<int,string> saveRecord = new Dictionary<int,string>();
        private float distance = 5;
        public GameObject items;
        private Dictionary<int , GameObject> itemGo = new Dictionary<int , GameObject>();
        public override void Init()
        {
            currentSaveIndex = SaveSystem.LoadIndex();
            List<string > itemRecorder = SaveSystem.LoadItems();
            if (itemRecorder != null)
            {
                for (int i = 0; i < itemRecorder.Count; i++)
                {
                    GameObject saveItem = Instantiate(Resources.Load("Prefabs/SaveItem") as GameObject, items.transform);
                    string[] departString = itemRecorder[i].Split(",");
                    string pictureName = departString[1];
                    int index = int.Parse(departString[0]);
                    saveRecord.Add(index, pictureName);
                    saveItem.transform.GetComponent<SaveItem>().ItemInit(Resources.Load<Sprite>("ScreenShot/" + pictureName), pictureName, index);
                    itemGo.Add(index, saveItem);
                }
            }
        }
        private int FindMinIndex()
        {
            int min = 9999;
            foreach(int keyIndex in saveRecord.Keys)
            {
                if (keyIndex < min)
                    min = keyIndex;
            }
            return min;
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
                        if (saveRecord.ContainsKey(currentSaveIndex))
                        {
                            saveRecord[currentSaveIndex] = pictureName;
                            Destroy(itemGo[currentSaveIndex]);
                            itemGo.Remove(currentSaveIndex);
                        }
                        else if (saveRecord.Count<=5)
                        {
                            saveRecord.Add(currentSaveIndex, pictureName);
                        }
                        else
                        {
                            saveRecord.Remove(FindMinIndex());
                            Destroy(itemGo[FindMinIndex()]);
                            itemGo.Remove(FindMinIndex());
                            saveRecord.Add(currentSaveIndex,pictureName);
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

