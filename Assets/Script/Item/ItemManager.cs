using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static Unity.IO.LowLevel.Unsafe.AsyncReadManagerMetrics;

public class ItemManager : MonoSingleton<ItemManager>
{
    [HideInInspector]
    public List<ItemScript> datas;
    public ItemData itemDatas;
    public void AddObject(int id,int num=1)
    {
        bool flag = true;
        foreach (ItemScript item in datas)
        {
            if (item.id == id)
            {
                item.num += num;
                flag = false;
                break;
            }
        }
        if (flag)
        {
            foreach (ItemDataBase data in itemDatas.datas)
            {
                if (data.id==id)
                {
                    GameObject itemGo = Instantiate(Resources.Load("Prefabs/Item") as GameObject);
                    int transformIndex =UIManager.Instance.GetUIWindow<BagUIWindow>().AddItemsToPage(itemGo.transform);
                    if (transformIndex != -1)
                        itemGo.transform.SetParent(UIManager.Instance.GetUIWindow<BagUIWindow>().bagItemsPanels[transformIndex]);
                    itemGo.transform.localScale = new Vector3(1, 1, 1);
                    ItemScript item = itemGo.GetComponent<ItemScript>();
                    item.InitItem(data);
                    datas.Add(item);
                }
            }
        }
    }
    public void AddObject(ItemDataBase dataBase,int num =1)
    {
        bool flag = true;
       foreach (ItemScript item in datas)
        {
            if (item.id == dataBase.id)
            {
                item.num += num;
                flag = false;
                break;
            }
        }
       if (flag)
        {
            GameObject itemGo = Instantiate(Resources.Load("Prefabs/Item") as GameObject);
            int transformIndex = UIManager.Instance.GetUIWindow<BagUIWindow>().AddItemsToPage(itemGo.transform);
            if (transformIndex != -1)
                itemGo.transform.SetParent(UIManager.Instance.GetUIWindow<BagUIWindow>().bagItemsPanels[transformIndex]);
            ItemScript item = itemGo.GetComponent<ItemScript>();
            item.InitItem(dataBase);
            datas.Add(item);
        }
    }
    public bool MinusObject(ItemDataBase dataBase, int num = 1)
    {
        foreach (ItemScript item in datas)
        {
            if (item.id == dataBase.id)
            {
                if (item.num == num)
                    DeletObject(item.id);
                else if (item.num < num)
                    return false;
                else
                    item.num -= num;
                break;
            }
        }
        return true;
    }
    public void DeletObject(int id)
    {
        foreach (ItemScript item in datas)
        {
            if (item.id == id)
            {
                datas.Remove(item);
                Destroy(item.gameObject);
                break;
            }
        }
    }
    public bool MinusObject(int id ,int num=1)
    {
        foreach (ItemScript item in datas)
        {
            if (item.id == id)
            {
                if(item.num == num)
                    DeletObject(item.id);
                else if (item.num < num)
                    return false;
                else
                    item.num -= num;
                break;
            }
        }
        return true;
    }
}