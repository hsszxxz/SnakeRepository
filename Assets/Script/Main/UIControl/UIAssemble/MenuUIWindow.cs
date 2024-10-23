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
        quitGame.onClick.AddListener(() => {Application.Quit();});
        loadGame.onClick.AddListener(LoadGame);
    }
    private void ContinueGame()
    {
        Time.timeScale = 1.0f; 
        ShutAndOpen(false);
        UIManager.Instance.GetUIWindow<MainUIWindow>().ShutAndOpen(true);
    }
    private void LoadGame()
    {

    }
}
