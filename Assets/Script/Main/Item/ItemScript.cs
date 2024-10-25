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
    private GameObject detailImage;
    private BagUIWindow bagUIWindow;
    private void Awake()
    {
        button = GetComponent<Button>();
        image = GetComponent<Image>();
        button.onClick.AddListener(ShowDetails);
    }

    private void Start()
    {
        bagUIWindow = UIManager.Instance.GetUIWindow<BagUIWindow>();
        detailImage = bagUIWindow.detailImage.gameObject;
    }
    private void ShowDetails()
    {
        bagUIWindow.detailText.text = data.description;
        detailImage.GetComponent<Image>(). sprite = data.img;
        detailImage.GetComponent<Button>().onClick.RemoveAllListeners();
        detailImage.GetComponent<Button>().onClick.AddListener(DectImg);
        bagUIWindow.detailImage.SetNativeSize();
    }
    private void DectImg()
    {
        StartCoroutine(CloseDetailImag(detailImage.transform.localPosition));
        detailImage.transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);
        detailImage.transform.localPosition = Vector3.zero;
        detailImage.GetComponent<Image>().sprite = data.detailImgWithDescribe;
        detailImage.GetComponent<Image>(). SetNativeSize();
    }
    IEnumerator CloseDetailImag(Vector3 detailImagPrimPos)
    {
        while (true)
        {
            if (Input.anyKeyDown)
            {
                break;
            }
            yield return null;
        }
        detailImage.transform.localPosition = detailImagPrimPos;
        detailImage.GetComponent <Image>().sprite = data.img;
        detailImage.GetComponent<Image>().SetNativeSize();
    }
    public void InitItem(ItemDataBase dataBase)
    {
        data = dataBase;
        image.sprite = dataBase.img;
        id = dataBase.id;
        num = 1;
    }
}

