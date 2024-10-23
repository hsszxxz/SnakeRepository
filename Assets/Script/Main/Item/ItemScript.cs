using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ItemScript : MonoBehaviour
{
    private Image image;
    [HideInInspector]
    public int num = 0;
    [HideInInspector]
    public int id;
    private ItemDataBase data;

    private Button button;
    private void Awake()
    {
        button = GetComponent<Button>();
        image = GetComponent<Image>();
        button.onClick.AddListener(ShowDetails);
    }

    private void ShowDetails()
    {
        BagUIWindow bagUIWindow = UIManager.Instance.GetUIWindow<BagUIWindow>();
        bagUIWindow.detailText.text = data.description;
        bagUIWindow.detailImage.sprite = data.detailImg;
        bagUIWindow.detailImage.SetNativeSize();
    }
    public void InitItem(ItemDataBase dataBase)
    {
        data = dataBase;
        image.sprite = dataBase.img;
        id = dataBase.id;
        num = 1;
    }
}

