using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SaveUIWindow:UIWindow
{
    public Button back;
    public Button readSave;
    private void Start()
    {
        back.onClick.AddListener(() => { ShutAndOpen(false); UIManager.Instance.GetUIWindow<MenuUIWindow>().ShutAndOpen(true); });
    }
}
