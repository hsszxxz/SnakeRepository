using control;
using save;
using sneak;
using System;
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
    public SaveItem saveItem;
    private void Start()
    {
        saveItems = new Dictionary<int,SaveItem>();
        back.onClick.AddListener(BackToMain);
        readSave.onClick.AddListener(SelectSave);
    }
    private void BackToMain()
    {
        ShutAndOpen(false); 
        UIManager.Instance.GetUIWindow<MenuUIWindow>().ShutAndOpen(true);
    }
    public override void ShutAndOpen(bool flag)
    {
        base.ShutAndOpen(flag);
        if (flag)
        {
            Dictionary<Button, Action> buttons = new Dictionary<Button, Action>()
            {
                {back, BackToMain },
                {readSave, SelectSave},
            };
            CharacterInput[] inputs = new CharacterInput[SneakManager.Instance.inputControlers.Count];
            for (int i = 0; i < inputs.Length; i++)
            {
                inputs[i] = SneakManager.Instance.inputControlers[i];
            }
            HandleButtonSelect.Instance.OpenHandleControl(buttons, inputs);
        }
        else
        {
            HandleButtonSelect.Instance.ShutHandleControl();
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Delete))
        {
            SaveSystem.DeleteSave(saveItem.saveIndex);
            Destroy(saveItem.gameObject);
        }
    }
    private void SelectSave()
    {
        ShutAndOpen(false);
        UIManager.Instance.GetUIWindow<MainUIWindow>().ShutAndOpen(true);
        Time.timeScale = 1.0f;
        if (saveItem.saveIndex!=0)
        {
            SaveSystem.LoadAll(saveItem.saveIndex);
            SaveManager.Instance.currentSaveIndex = saveItem.saveIndex;
        }
    }

}
