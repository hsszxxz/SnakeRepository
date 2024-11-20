using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Windows;
namespace control
{
    ///<summary>
    ///手柄点选按钮
    ///<summary>
    public class HandleButtonSelect:MonoSingleton<HandleButtonSelect>
    {
        public Dictionary<Button,Action> buttonsAndListeners;
        private List<GameObject> buttonTishi;
        private CharacterInput beforeInput;
        private CharacterInput currentInput;
        private int indexValue;
        private int index
        {
            get { return indexValue; }
            set
            {
                indexValue = value;
                for (int i = 0; i < buttonTishi.Count; i++)
                {
                    if (i == value)
                    {
                        buttonTishi[i].SetActive(true);
                    }
                    else
                    {
                        buttonTishi[i].SetActive(false);
                    }
                }
            }
        }
        private void Start()
        {
            currentInput = new CharacterInput();
        }
        public void OpenHandleControl(Dictionary<Button,Action> buttons, CharacterInput inputs)
        {
            beforeInput = inputs;
            inputs.Disable();
            foreach (var button in buttons.Keys)
            {
                buttonTishi.Add(button.transform.GetChild(0).gameObject);
            }
            index = 0;
            currentInput.handleplay.Move.started += tp => index = (index + (int)tp.ReadValue<Vector2>().y*2-1)%buttons.Count;
            currentInput.Enable();
        }
        public void ShutHandleControl()
        {
            currentInput.handleplay.Move.Reset();
            currentInput.Disable();
            beforeInput.Enable();
            buttonsAndListeners.Clear();
            buttonTishi.Clear();
        }
    }
}

