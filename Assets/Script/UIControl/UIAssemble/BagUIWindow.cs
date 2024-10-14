using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BagUIWindow:UIWindow
{
    public Button close;
    private void Start()
    {
        close.onClick.AddListener(CloseBag);
    }
    private void CloseBag()
    {
        ShutAndOpen(false);
    }
}

