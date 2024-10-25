using save;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SaveUIWindow:UIWindow
{
    public Button back;
    public Button readSave;
    [HideInInspector]
    public Dictionary<int,SaveItem> saveItems;
    [HideInInspector]
    public int saveIndex=0;
    private void Start()
    {
        saveItems = new Dictionary<int,SaveItem>();
        back.onClick.AddListener(() => { ShutAndOpen(false); UIManager.Instance.GetUIWindow<MenuUIWindow>().ShutAndOpen(true); });
        readSave.onClick.AddListener(SelectSave);
    }
    private void SelectSave()
    {
        ShutAndOpen(false);
        UIManager.Instance.GetUIWindow<MainUIWindow>().ShutAndOpen(true);
        Time.timeScale = 1.0f;
        if (saveIndex!=0)
        {
            SaveSystem.LoadAll(saveIndex);
            SaveManager.Instance.currentSaveIndex = saveIndex;
        }
    }

}
