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

