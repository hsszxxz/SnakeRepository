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
            if (Input.GetKeyDown(KeyCode.E))
            {
                SaveSystem.SaveSnake();
            }
            else if (Input.GetKeyDown(KeyCode.U))
            {
                SaveSystem.LoadSnake();
            }
        }
    }
}

