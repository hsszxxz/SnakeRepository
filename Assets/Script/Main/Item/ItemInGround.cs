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
    private bool isChat = false;
    protected override void ShowPanel()
    {
        base.ShowPanel();
        if (id==1 && !isChat)
        {
            isChat = true;
            FungusController.Instance.StartBlock("1µı∆ø");
        }
    }
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

