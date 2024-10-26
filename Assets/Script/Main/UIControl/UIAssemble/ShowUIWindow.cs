using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ShowUIWindow:UIWindow
{
    public Image itemImage;
    public Button cancel;
    private void Start()
    {
        cancel.onClick.AddListener(CloseWindow);
    }
    private void CloseWindow()
    {
        Time.timeScale = 1.0f;
        UIManager.Instance.GetUIWindow<MainUIWindow>().ShutAndOpen(true);
        ShutAndOpen(false);
    }
    public void ShowItem(ItemDataBase item)
    {
        Time.timeScale = 0f;
        itemImage.sprite = item.detailImgWithDescribe;
        itemImage.SetNativeSize();
    }
}

