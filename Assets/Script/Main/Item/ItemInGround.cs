using interection;
using sneak;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
///<summary>
///
///<summary>
public class ItemInGround : InteractWithDoor
{
    public int id;
    protected override void InterectMethod()
    {
        UIManager.Instance.GetUIWindow<MainUIWindow>().ShutAndOpen(false);
        ItemManager.Instance.AddObject(id);
        ShowUIWindow showUIWindow = UIManager.Instance.GetUIWindow<ShowUIWindow>();
        showUIWindow.ShutAndOpen(true);
        showUIWindow.ShowItem(ItemManager.Instance.IdToData(id));
        Destroy(tiShiPanel);
        Destroy(gameObject);
    }
}

