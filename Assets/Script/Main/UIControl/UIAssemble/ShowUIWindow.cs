using control;
using sneak;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ShowUIWindow:UIWindow
{
    public Image itemImage;
    public Button cancel;
    private ItemDataBase itemData;
    private bool isChat = false;
    private void Start()
    {
        cancel.onClick.AddListener(CloseWindow);
    }
    public override void ShutAndOpen(bool flag)
    {
        base.ShutAndOpen(flag);
        if (flag)
        {
            Dictionary<Button, Action> buttons = new Dictionary<Button, Action>()
            { { cancel,CloseWindow}};
            CharacterInput[] inputs = new CharacterInput[SneakManager.Instance.inputControlers.Count];
            for (int i = 0; i < inputs.Length; i++)
            {
                inputs[i] = SneakManager.Instance.inputControlers[i];
            }
            HandleButtonSelect.Instance.OpenHandleControl(buttons, inputs);
        }
        else
        {
            HandleButtonSelect.Instance.ShutHandleControl();
        }
    }
    private void CloseWindow()
    {
        if (itemData.id == 1 && !isChat)
        {
            isChat = true;
            StartCoroutine(LateCall());
        }
        Time.timeScale = 1.0f;
        UIManager.Instance.GetUIWindow<MainUIWindow>().ShutAndOpen(true);
        ShutAndOpen(false);
    }
    IEnumerator LateCall()
    {
        yield return null;
        FungusController.Instance.StartBlock("1µı∆ø");
    }
    public void ShowItem(ItemDataBase item)
    {
        Time.timeScale = 0f;
        itemImage.sprite = item.detailImgWithDescribe;
        itemImage.SetNativeSize();
        itemData = item;
    }
}

