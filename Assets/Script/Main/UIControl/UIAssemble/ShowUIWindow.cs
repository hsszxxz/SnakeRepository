using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ShowUIWindow:UIWindow
{
    public Image itemImage;
    public Text describe;
    public Button cancel;
    private void Start()
    {
        cancel.onClick.AddListener(CloseWindow);
    }
    private void CloseWindow()
    {
        Time.timeScale = 1.0f;
        ShutAndOpen(false);
    }
    public void ShowItem(ItemDataBase item)
    {
        Time.timeScale = 0f;
        itemImage.sprite = item.img;
        describe.text = item.description;
    }
}

