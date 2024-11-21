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
        private CharacterInput[] beforeInput;
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
        public override void  Init()
        {
            base.Init();
            currentInput = new CharacterInput();
            buttonTishi = new List<GameObject>();
            buttonsAndListeners = new Dictionary<Button,Action>();
        }
        public void OpenHandleControl(Dictionary<Button, Action> buttons, CharacterInput[] inputs)
        {
            beforeInput = inputs;
            foreach (var input in beforeInput)
            {
                input.Disable();
            }
            foreach (var button in buttons.Keys)
            {
                buttonTishi.Add(button.transform.GetChild(0).gameObject);
            }
            index = 0;
            buttonsAndListeners = buttons;
            currentInput.handleplay.Move.started += tp => { index = (index - (int)tp.ReadValue<Vector2>().y + buttonsAndListeners.Count) % buttonsAndListeners.Count; index = (index - (int)tp.ReadValue<Vector2>().x * 2 + buttonsAndListeners.Count) % buttonsAndListeners.Count; };
            currentInput.handleplay.Confirm.started += tp=>OpenListener();
            StartCoroutine(OpenCurrent());
        }
        IEnumerator OpenCurrent()
        {
            yield return null;
            currentInput.Enable();
        }
        private void OpenListener()
        {
            Button button = buttonTishi[index].GetComponentInParent<Button>();
            buttonsAndListeners[button].Invoke();
        }
        public void ShutAndOpenHandleControl(bool flag)
        {
            if (flag)
            {
                currentInput.Enable();
            }
            else
            {
                currentInput.Disable();
            }
        }
        public void ShutHandleControl()
        {
            currentInput.handleplay.Move.Reset();
            currentInput.Disable();
            if (beforeInput != null)
            {
                foreach (var input in beforeInput)
                {
                    if (input != null)
                    {
                        input.Enable();
                    }
                }
            }
            buttonsAndListeners.Clear();
            buttonTishi.Clear();
        }
    }
}

