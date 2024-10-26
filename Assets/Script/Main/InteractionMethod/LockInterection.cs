using enemy;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace interection
{
    ///<summary>
    ///
    ///<summary>
    public class LockInterection : InteractWithDoor
    {
        public bool FirstBossLock;
        public GameObject airWall;
        protected override void Start()
        {

        }
        protected override void InterectMethod()
        {
            if (FirstBossLock)
            {
                if (ItemManager.Instance.IdInBag(8))
                {
                    airWall.SetActive(false);
                    tiShiPanel.GetComponentInChildren<Text>().text = "允许通行";
                }
                else
                {
                    tiShiPanel.GetComponentInChildren<Text>().text = "无法打开！";
                }
            }
        }
    }
}

