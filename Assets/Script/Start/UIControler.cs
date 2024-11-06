using ns;
using save;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
    private void Start()
    {
        startGame.onClick.AddListener(StartGame);
        continueGame.onClick.AddListener(ContinueGame);
        maker.onClick.AddListener(ShowMakers);
        quit.onClick.AddListener(() => { Application.Quit(); });
        lateLoadGame = DontDestroyGo.GetComponent<LateLoadGame>();
        DontDestroyOnLoad(DontDestroyGo);
    }
    private void StartGame()
    {
        lateLoadGame.StartCoroutine(LateSart());
        SceneManager.LoadScene("MainScene");
    }
    IEnumerator LateSart()
    {
        yield return  null;
        SavePoint savePoint = SaveSystemManager.Instance.CreateSaveItem();
        SaveManager.Instance.currentSaveIndex = savePoint.saveID;
        SaveManager.Instance.isNewSave = true;
    }
    private void ContinueGame()
    {
        List<SavePoint> points = SaveSystemManager.Instance.GetAllSaveItemByUpdateTime();
        if (points.Count == 0)
            return;
        else
        {
            lateLoadGame.StartCoroutine(LateLoad(points[0].saveID));
            SceneManager.LoadScene("MainScene");
        }
    }
    IEnumerator LateLoad(int index)
    {
        yield return null;
        SaveManager.Instance.currentSaveIndex = index;
        SaveSystem.LoadAll(index);
        SaveManager.Instance.isNewSave = false;
    }
    private void ShowMakers()
    {
        Makers.SetActive(true);
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
        Makers.SetActive(false);
    }
}

