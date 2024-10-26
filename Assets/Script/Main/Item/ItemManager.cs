using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static Unity.IO.LowLevel.Unsafe.AsyncReadManagerMetrics;

public class ItemManager : MonoSingleton<ItemManager>
{
    [HideInInspector]
    public List<ItemScript> datas = new List<ItemScript>();
    public ItemData itemDatas;
    public ItemDataBase IdToData(int id)
    {
        foreach (ItemDataBase item in itemDatas.datas)
        {
            if (item.id == id) return item;
        }
        return null;
    }
    public bool IdInBag(int id)
    {
        foreach (ItemScript item in datas)
        {
            if (id== item.id)
                return true;
        }
        return false;
    }
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
            ItemDataBase data = IdToData(id);
            if (data != null)
            {
                GameObject itemGo = Instantiate(Resources.Load("Prefabs/Item") as GameObject);
                int transformIndex = UIManager.Instance.GetUIWindow<BagUIWindow>().AddItemsToPage(itemGo.GetComponent<RectTransform>());
                if (transformIndex != -1)
                    itemGo.transform.SetParent(UIManager.Instance.GetUIWindow<BagUIWindow>().bagItemsPanels[transformIndex]);
                itemGo.transform.localScale = new Vector3(1, 1, 1);
                itemGo.transform.localRotation = Quaternion.identity;
                itemGo.GetComponent<RectTransform>().localPosition = new Vector3(0,0, 0); 
                ItemScript item = itemGo.GetComponent<ItemScript>();
                item.InitItem(data);
                datas.Add(item);
            }
        }
    }
    public void CleanAllItems()
    {
        UIManager.Instance.GetUIWindow<BagUIWindow>().CleanBag();
        datas.Clear();
    }
    public void DeletObject(int id)
    {
        foreach (ItemScript item in datas)
        {
            if (item.id == id)
            {
                datas.Remove(item);
                UIManager.Instance.GetUIWindow<BagUIWindow>().MinusItemFromPage(item.transform);
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