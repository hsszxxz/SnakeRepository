using save;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ns
{
    ///<summary>
    ///
    ///<summary>
    public class Test : MonoBehaviour
    {
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.X))
            {
                SaveSystem.SaveAll();
            }
            else if (Input.GetKeyDown(KeyCode.U))
            {
                SaveSystem.LoadAll();
            }
            else if (Input.GetKeyDown(KeyCode.V))
            {
                ItemManager.Instance.AddObject(1, 1);
                ItemManager.Instance.AddObject(2, 1);
            }
            else if (Input.GetKeyDown(KeyCode.B))
            {
                ItemManager.Instance.MinusObject(1, 1);
            }
        }
    }
}

