using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ShowUIWindow:UIWindow
{
    public Image itemImage;
    public void ShowItem(ItemDataBase item)
    {
        itemImage.sprite = item.img;
    }
}

