using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class BagUIWindow:UIWindow
{
    public Button close;
    public Button turnLeft;
    public Button turnRight;

    [HideInInspector]
    public Dictionary<int, List<Transform>> pageItems = new Dictionary<int, List<Transform>>();
    [Tooltip("一页能放几个物品")]
    public int maxItemNum;

    [HideInInspector]
    public Dictionary<int,RectTransform>bagItemsPanels = new Dictionary<int,RectTransform>() ;

    public Transform bag;

    //每两页之间的距离
    private Vector3 offsetPos = new Vector3(560,0,0);
    //当前页数
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
                turnRight.interactable = false;
            }
            else
            {
                turnRight.interactable = true;
            }
            if (value==1)
            {
                turnLeft.interactable = false;
            }
            else
            {
                turnLeft.interactable = true;
            }
        }
    }
    private int maxPage;
    private void Start()
    {
        close.onClick.AddListener(CloseBag);
        InitBag();
        turnLeft.onClick.AddListener(TurnLeftPage);
        turnRight.onClick.AddListener(TurnRightPage);
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
        turnRight.interactable = false ;
        turnLeft.interactable = false ;
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
        ShutAndOpen(false);
    }
}

