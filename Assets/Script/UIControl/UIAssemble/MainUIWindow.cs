using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainUIWindow:UIWindow
{
    public Button bagButton;
    private void Start()
    {
        bagButton.onClick.AddListener(OpenBag);
    }
    private void OpenBag()
    {

    }
}

