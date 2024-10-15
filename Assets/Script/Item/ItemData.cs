using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName ="ItemDate")]
public class ItemData:ScriptableObject
{
    public List<ItemDataBase> datas;
}
[Serializable]
public class ItemDataBase
{
    public  int id;
    public string name;
    public string description;
    public Sprite img;
}



