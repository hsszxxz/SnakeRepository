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
        public bool SecondBossLock;
        public GameObject airWall;
        protected override void Start()
        {

        }
        protected override void InterectMethod()
        {
            bool isOpen = true;
            if (FirstBossLock)
            {
                if (!EnemyManager.Instance.enemyDebate[0])
                {
                    isOpen = false;
                }
            }
            if (SecondBossLock)
            {
                if (!EnemyManager.Instance.enemyDebate[1])
                {
                    isOpen = false;
                }
            }
            if (!isOpen)
            {
                tiShiPanel.GetComponentInChildren<Text>().text = "无法打开！";
            }
            airWall.SetActive(!isOpen);

        }
    }
}

