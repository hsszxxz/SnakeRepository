using sneak;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainUIWindow:UIWindow
{
    public Button bagButton;
    public Button stop;
    private void Start()
    {
        bagButton.onClick.AddListener(OpenBag);
        stop.onClick.AddListener(StopGame);
    }
    private void OpenBag()
    {
        Time.timeScale = 0;
        UIManager.Instance.GetUIWindow<BagUIWindow>().ShutAndOpen(true);
        ShutAndOpen(false);
    }
    private void StopGame()
    {
        Time.timeScale = 0;
        UIManager.Instance.GetUIWindow<MenuUIWindow>().ShutAndOpen(true);
        ShutAndOpen(false);
    }
    private void Update()
    {
        foreach (var input in SneakManager.Instance.inputControlers)
        {
            if (input.handleplay.Cancel.WasPressedThisFrame())
            {
                Time.timeScale = 0;
                ShutAndOpen(false);
                UIManager.Instance.GetUIWindow<MenuUIWindow>().ShutAndOpen(true);
                break;
            }
        }
    }
}

