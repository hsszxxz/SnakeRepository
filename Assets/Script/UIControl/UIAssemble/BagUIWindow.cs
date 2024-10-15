using System.Collections;
using System.Collections.Generic;
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
    public Dictionary<int,Transform>bagItemsPanels = new Dictionary<int,Transform>() ;

    private float panelDis = 560;

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
        maxPage = 1;
        page = 1;
        close.onClick.AddListener(CloseBag);
        Transform panel = Instantiate(Resources.Load("Prefabs/BagItems") as GameObject, bag).transform;
        bagItemsPanels.Add(maxPage, panel);
        pageItems.Add(maxPage, new List<Transform>());
        turnLeft.onClick.AddListener(TurnLeftPage);
        turnRight.onClick.AddListener(TurnRightPage);
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
    IEnumerator TurnToPage(Vector3 target,Transform page)
    {
        turnRight.interactable = false ;
        turnLeft.interactable = false ;
        while(Vector3.Distance(page.localPosition,target) >0.5f)
        {
            page.localPosition = Vector3.Lerp(page.localPosition, target, 0.2f);
            yield return null;
        }
        turnRight.interactable = true;
        turnLeft.interactable = true;
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
            Transform panel = Instantiate(Resources.Load("Prefabs/BagItems") as GameObject, bag).transform;
            panel.localPosition = bagItemsPanels[maxPage].localPosition + offsetPos;
            maxPage += 1;
            page = page;
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

