using control;
using save;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class UIControler : MonoBehaviour
{
    public Button startGame;
    public Button continueGame;
    public Button maker;
    public Button quit;
    public GameObject Makers;
    public GameObject DontDestroyGo;
    private LateLoadGame lateLoadGame;
    public InputChoose inputChoose;
    private CharacterInput inputActions;
    private void Start()
    {
        startGame.onClick.AddListener(StartGame);
        continueGame.onClick.AddListener(ContinueGame);
        maker.onClick.AddListener(ShowMakers);
        quit.onClick.AddListener(QuitGame);
        lateLoadGame = DontDestroyGo.GetComponent<LateLoadGame>();
        DontDestroyOnLoad(DontDestroyGo);

    }
    private void OnEnable()
    {
        inputActions = new CharacterInput();
        inputChoose.inputAction = inputActions;
        Dictionary<Button, Action> buttons = new Dictionary<Button, Action>()
        {
            {startGame,StartGame },
            {continueGame,ContinueGame},
            {quit,QuitGame},
            {maker,ShowMakers },
        };
        CharacterInput[] inputs = new CharacterInput[1];
        inputs[0] = inputActions;
        HandleButtonSelect.Instance.OpenHandleControl(buttons, inputs);
    }
    private void OnDisable()
    {
        HandleButtonSelect.Instance.ShutHandleControl();
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void StartGame()
    {
        inputChoose.gameObject.SetActive(true);
        HandleButtonSelect.Instance.ShutAndOpenHandleControl(false);
        inputChoose.gameStart = () =>
        {
            lateLoadGame.StartCoroutine(LateSart());
            SceneManager.LoadScene("MainScene");
        };
    }
    IEnumerator LateSart()
    {
        yield return  null;
        SavePoint savePoint = SaveSystemManager.Instance.CreateSaveItem();
        SaveManager.Instance.currentSaveIndex = savePoint.saveID;
        SaveManager.Instance.isNewSave = true;
        HandleButtonSelect.Instance.ShutAndOpenHandleControl(true);
    }
    public void ContinueGame()
    {
        HandleButtonSelect.Instance.ShutAndOpenHandleControl(false);
        List<SavePoint> points = SaveSystemManager.Instance.GetAllSaveItemByUpdateTime();
        if (points.Count == 0)
            return;
        inputChoose.gameObject.SetActive(true);
        inputChoose.gameStart =()=>
        {
            Time.timeScale = 1;
            List<SavePoint> points = SaveSystemManager.Instance.GetAllSaveItemByUpdateTime();
            lateLoadGame.StartCoroutine(LateLoad(points[0].saveID));
            SceneManager.LoadScene("MainScene");
        };
    }
    IEnumerator LateLoad(int index)
    {
        yield return null;
        SaveManager.Instance.currentSaveIndex = index;
        SaveSystem.LoadAll(index);
        SaveManager.Instance.isNewSave = false;
        HandleButtonSelect.Instance.ShutAndOpenHandleControl(true);
    }
    private void ShowMakers()
    {
        Makers.SetActive(true);
        HandleButtonSelect.Instance.ShutAndOpenHandleControl(false);
        StartCoroutine(CancelMaker());
    }
    IEnumerator CancelMaker()
    {
        while (true)
        {
            yield return null;
            if (Input.GetMouseButtonDown(0) || Input.anyKeyDown)
            {
                break;
            }
        }
        HandleButtonSelect.Instance.ShutAndOpenHandleControl(true);
        Makers.SetActive(false);
    }
}

