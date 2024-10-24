using save;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MenuUIWindow : UIWindow
{
    public Button continueGame;
    public Button quitGame;
    public Button loadGame;
    private void Start()
    {
        continueGame.onClick.AddListener(ContinueGame);
        quitGame.onClick.AddListener(QuitGame);
        loadGame.onClick.AddListener(LoadGame);
    }
    private void QuitGame()
    {
        List<string> recordList = new List<string>();
        foreach(int key in SaveManager.Instance.saveRecord.Keys)
        {
            string endRecord = key.ToString()+","+ SaveManager.Instance.saveRecord[key];
            recordList.Add(endRecord);
        }
        SaveSystem.SaveSaveItems(recordList);
        Application.Quit();
    }
    private void ContinueGame()
    {
        Time.timeScale = 1.0f; 
        ShutAndOpen(false);
        UIManager.Instance.GetUIWindow<MainUIWindow>().ShutAndOpen(true);
    }
    private void LoadGame()
    {
        ShutAndOpen(false) ;
        UIManager.Instance.GetUIWindow<SaveUIWindow>().ShutAndOpen(true);
    }
}

