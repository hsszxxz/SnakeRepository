using control;
using Newtonsoft.Json;
using save;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using move;
namespace ns
{
    ///<summary>
    ///
    ///<summary>
    public class Test : MonoBehaviour
    {
        private CharacterInput characterInput;
        private void Start()
        {
            //characterInput = new CharacterInput();
            //characterInput.Enable();
            //characterInput.gameplay.Move.started += ct => Debug.Log(ct.ReadValue<Vector2>());
            //String.Format("{0}MotorControl", InputDevice.KeyBoard.ToString())
            //Type type = Type.GetType(String.Format("move.{0}MotorControl", InputDevice.KeyBoard.ToString()));
            //object[] objects = { Kit.Right, transform }; 
            //object instance = Activator.CreateInstance(type,objects);
        }
        private void Update()
        {
        }
    }
}

