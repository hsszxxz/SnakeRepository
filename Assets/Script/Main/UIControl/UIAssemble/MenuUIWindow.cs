using control;
using save;
using sneak;
using System;
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
    public override void ShutAndOpen(bool flag)
    {
        base.ShutAndOpen(flag);
        if (flag)
        {
            Dictionary<Button, Action> buttons = new Dictionary<Button, Action>()
            {
                {continueGame,ContinueGame },
                {loadGame,LoadGame },
                {quitGame,QuitGame},
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
    private void QuitGame()
    {
        SaveSystem.SaveAll(SaveManager.Instance.currentSaveIndex);
        string pictureName = SaveSystemManager.Instance.GetSaveItem(SaveManager.Instance.currentSaveIndex).LastSaveTime.ToString("yyyy-MM-dd-HH-mm-ss");
        ScreenCapture.CaptureScreenshot(SaveManager.Instance.path + "/" + pictureName + ".png");
        ShutAndOpen(false);
        StartCoroutine(LateLoad());
    }
    IEnumerator LateLoad()
    {
        yield return null;
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
        ShutAndOpen(false);
        StartCoroutine(LateOpen());
    }
    IEnumerator LateOpen()
    {
        yield return null;
        UIManager.Instance.GetUIWindow<SaveUIWindow>().ShutAndOpen(true);
    }
}

