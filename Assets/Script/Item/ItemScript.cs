using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ItemScript : MonoBehaviour
{
    private Image image;
    [HideInInspector]
    public string name;
    [HideInInspector]
    public int num = 0;
    [HideInInspector]
    public int id;
    private void Awake()
    {
        image = GetComponent<Image>();
    }
    public void InitItem(ItemDataBase dataBase)
    {
        image.sprite = dataBase.img;
        name = dataBase.name;
        id = dataBase.id;
        num = 1;
    }
}

