using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BagUIWindow:UIWindow
{
    public Button close;
    //public Button turnLeft;
    //public Button turnRight;

    [HideInInspector]
    public Dictionary<int, List<Transform>> pageItems = new Dictionary<int, List<Transform>>();
    [Tooltip("һҳ�ܷż�����Ʒ")]
    public int maxItemNum;
    [Tooltip("��ͼƬ��λ��")]
    public Image detailImage;
    [Tooltip("�����ֵ�λ��")]
    public Text detailText;
    [Tooltip("�Ŵ�ͼƬ")]
    public Button detailImag;

    [HideInInspector]
    public Dictionary<int,RectTransform>bagItemsPanels = new Dictionary<int,RectTransform>() ;

    public Transform bag;

    //ÿ��ҳ֮��ľ���
    private Vector3 offsetPos = new Vector3(560,0,0);
    //��ǰҳ��
    private int pageValue;
    private int page
    {
        get
        {
            return pageValue;
        }
        set
        {
            pageValue = value;
            if(value==maxPage)
            {
                //turnRight.interactable = false;
            }
            else
            {
                //turnRight.interactable = true;
            }
            if (value==1)
            {
                //turnLeft.interactable = false;
            }
            else
            {
                //turnLeft.interactable = true;
            }
        }
    }
    private int maxPage;
    private Vector3 detailImagPrimScale;
    private Vector3 detailImagPrimPos;
    private void Start()
    {
        close.onClick.AddListener(CloseBag);
        InitBag();
        //turnLeft.onClick.AddListener(TurnLeftPage);
        //turnRight.onClick.AddListener(TurnRightPage);
        detailImag.onClick.AddListener(CheckDetailImag);
        detailImagPrimScale = detailImag.transform.localScale;
        detailImagPrimPos = detailImag.transform.localPosition;
    }
    private void CheckDetailImag()
    {
        detailImag.transform.localScale = new Vector3(1,1,1);
        detailImag.transform.localPosition = Vector3.zero;
        StartCoroutine(CloseDetailImag());
    }
    IEnumerator CloseDetailImag()
    {
        while (true)
        {
            if (Input.anyKeyDown)
            {
                break;
            }
            yield return null;
        }
        detailImag.transform.localScale = detailImagPrimScale;
        detailImag.transform.localPosition = detailImagPrimPos;
    }
    private void InitBag()
    {
        maxPage = 1;
        page = 1;
        RectTransform panel = Instantiate(Resources.Load("Prefabs/BagItems") as GameObject, bag).GetComponent<RectTransform>();
        bagItemsPanels.Add(maxPage, panel);
        pageItems.Add(maxPage, new List<Transform>());
    }

    private void TurnLeftPage()
    {
        TurnPage(-1);
    }
    private void TurnRightPage()
    {
        TurnPage(1);
    }
    private void TurnPage(int pageChange)
    {
        foreach(Transform t in bagItemsPanels.Values)
        {
            Vector3 target = t.transform.localPosition- offsetPos*pageChange;
            StartCoroutine(TurnToPage(target,t));
        }
        page += pageChange;
    }
    IEnumerator TurnToPage(Vector3 target,Transform pageTransform)
    {
        //turnRight.interactable = false ;
        //turnLeft.interactable = false ;
        while(Vector3.Distance(pageTransform.localPosition,target) >0.5f)
        {
            pageTransform.localPosition = Vector3.Lerp(pageTransform.localPosition, target, 0.2f);
            yield return null;
        }
        page = pageValue;
    }
    private  void DeletOnePage(int pageNum)
    {
        for (int j = bagItemsPanels.Count;j>pageNum; j--)
        {
            bagItemsPanels[j].localPosition = bagItemsPanels[j-1].localPosition;
        }
        for (int i = pageNum; i < bagItemsPanels.Count; i++)
        {
            bagItemsPanels[i] = bagItemsPanels[i + 1];
            pageItems[i] = pageItems[i + 1];
        }
        bagItemsPanels.Remove(maxPage);
        pageItems.Remove(maxPage);
        maxPage -= 1;
        if (page > maxPage )
        {
               TurnPage(-1);
        }
        page = pageValue;
    }
    public void CleanBag()
    {
        pageItems.Clear();
        foreach(var bagPage in bagItemsPanels.Values)
        {
            Destroy(bagPage.gameObject);
        }
        bagItemsPanels.Clear();
        InitBag();
    }
    public void MinusItemFromPage(Transform item)
    {
        for (int i = 0; i < pageItems.Count; i++)
        {
            if (pageItems[i + 1].Contains(item))
            {
                pageItems[i + 1].Remove(item);
                Destroy(item.gameObject);
                if (pageItems[i + 1].Count == 0)
                {
                    GameObject deletGo = bagItemsPanels[i + 1].gameObject;
                    DeletOnePage(i + 1);
                    Destroy(deletGo);
                }
                break;
            }
        }
    }
    public int AddItemsToPage(Transform item)
    {
        bool flag = true;
        for (int i =0;i <pageItems.Count;i++) 
        {
            if (pageItems[i+1].Count <maxItemNum)
            {
                pageItems[i+1].Add(item);
                flag = false;
                return i+1;
            }
        }
        if (flag)
        {
            RectTransform panel = Instantiate(Resources.Load("Prefabs/BagItems") as GameObject, bag).GetComponent<RectTransform>();
            panel.localPosition = bagItemsPanels[maxPage].localPosition + offsetPos;
            maxPage += 1;
            page = pageValue;
            bagItemsPanels.Add(maxPage,panel);
            pageItems.Add(maxPage, new List<Transform>() { item });
            return maxPage;
        }
        return -1;
    }
    private void CloseBag()
    {
        Time.timeScale = 1;
        UIManager.Instance.GetUIWindow<MainUIWindow>().ShutAndOpen(true);
        ShutAndOpen(false);
    }
}

