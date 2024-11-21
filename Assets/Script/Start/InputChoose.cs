using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using control;
using UnityEngine.UI;
using System;
using NUnit.Framework;

///<summary>
///
///<summary>
public class InputChoose : MonoBehaviour
{
    [HideInInspector]
    public Action gameStart;
    private int indexValue;
    private int index
    {
        get { return indexValue; }
        set
        {
            indexValue = value;
            if (headtishi != null)
            {
                for (int i = 0; i < headtishi.Length; i++)
                {
                    if (i == value && headtishi[i] != null)
                    {
                        headtishi[i].SetActive(true);
                    }
                    else if (headtishi[i] != null)
                    {
                        headtishi[i].SetActive(false);
                    }
                }
            }
        }
    }
    public GameObject[] headChooose;
    public GameObject[] headtishi;
    [HideInInspector]
    public  CharacterInput inputAction;
    public LateLoadGame loadGame;
    private Image[] headChooseImage;
    private bool[] isReady = {false,false};
    private void OnEnable()
    {
        headChooseImage = new Image[2];
        headChooseImage[0] = headChooose[0].GetComponent<Image>();
        headChooseImage[1] = headChooose[1].GetComponent<Image>();
        index = 0;
        headChooose[0].GetComponent<Button>().onClick.AddListener(() => index=0);
        headChooose[1].GetComponent<Button>().onClick.AddListener(() => index=1);
        inputAction.Enable();
        inputAction.gameplay.ArrowMove.started += tp => index = (int)(tp.ReadValue<Vector2>().x + 0.99f);
        inputAction.gameplay.WASDMove.started += tp => index = (int)(tp.ReadValue<Vector2>().x + 0.99f);
        inputAction.handleplay.Move.started += tp => index = (int)(tp.ReadValue<Vector2>().x + 0.99f);
        inputAction.gameplay.Confirm.started += tp => { ConfirmChoose(InputDevice.KeyBoard); };
        inputAction.handleplay.Confirm.started += tp => { ConfirmChoose(InputDevice.Handle); };
        inputAction.gameplay.Cancel.started += tp => { Cancel(); };
        inputAction.handleplay.Cancel.started += tp => { Cancel(); };
        
    }
    private void Cancel()
    {
        isReady[index] = false;
        if (headChooseImage[index]!=null)
        {
            headChooseImage[index].color = Color.red;
        }
    }
    private void ConfirmChoose(InputDevice device)
    {
        if (headChooseImage[index] != null)
        {
            headChooseImage[index].color = Color.green;
        }
        isReady[index] = true; 
        loadGame.headDevices[index] = device;
    }
    private void Update()
    {
        if (isReady[0] && isReady[1])
        {
            gameStart();
            this.gameObject.SetActive(false);
            isReady[0] = false;
            isReady[1] = false;
        }
    }
    private void OnDisable()
    {
        inputAction.Disable();
    }
}


