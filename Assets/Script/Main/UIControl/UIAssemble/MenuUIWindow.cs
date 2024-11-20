using save;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
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
        SaveSystem.SaveAll(SaveManager.Instance.currentSaveIndex);
        string pictureName = SaveSystemManager.Instance.GetSaveItem(SaveManager.Instance.currentSaveIndex).LastSaveTime.ToString("yyyy-MM-dd-HH-mm-ss");
        ScreenCapture.CaptureScreenshot(SaveManager.Instance.path + "/" + pictureName + ".png");
        SceneManager.LoadScene("StartScene");
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

