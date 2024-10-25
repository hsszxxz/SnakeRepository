using ns;
using save;
using System.Collections;
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
        SaveSystem.SaveIndex(SaveSystem.LoadIndex() + 1);
        SceneManager.LoadScene("MainScene");
    }
    private void ContinueGame()
    {
        if (SaveSystem.LoadIndex() == 0)
            return;
        else
        {
            SceneManager.LoadScene("MainScene");
            lateLoadGame.StartCoroutine(LateLoad());
        }
    }
    IEnumerator LateLoad()
    {
        yield return null;
        SaveManager.Instance.currentSaveIndex = SaveSystem.LoadIndex();
        SaveSystem.LoadAll(SaveSystem.LoadIndex());
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

