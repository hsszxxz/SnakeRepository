using control;
using save;
using sneak;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class DeadUiWindow : UIWindow
{
    public Button newGame;
    public Button quitGame;
    public Button loadGame;
    private void Start()
    {
        newGame.onClick.AddListener(ContinueGame);
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
            {newGame,ContinueGame },
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
        ShutAndOpen(false);
        SceneManager.LoadScene("StartScene");
        SaveSystemManager.Instance.DeleteSaveItem(SaveManager.Instance.currentSaveIndex);
    }
    private void ContinueGame()
    {
        Time.timeScale = 1.0f;
        ShutAndOpen(false);
        UIManager.Instance.GetUIWindow<MainUIWindow>().ShutAndOpen(true);
        SceneManager.LoadScene("StartScene");
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

