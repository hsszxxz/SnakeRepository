using sneak;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class LouTiJianJuQing : MonoBehaviour
{
    public float distacne;
    private Transform target;
    public Transform MoveTarget;
    public GameObject camera;
    public List<Sprite> player1choice;
    public List<Sprite> player2choice;
    private bool isChoose = false;
    private void Start()
    {
        target  = FindSneakPosition.FindTarget(transform);
    }
    public void EventChoice(int index1, int index2)
    {
        if (index1 == 0 &&index2==0)
        {
            SceneMove.MoveSneak(MoveTarget.position, camera);
        }
        UIManager.Instance.GetUIWindow<MainUIWindow>().ShutAndOpen(true);
    }
    private void Update()
    {
        if (target == null)
        {
            target = FindSneakPosition.FindTarget(transform);
        }
        else
        {
            if (Vector2.Distance(transform.position, target.position)<=distacne && !isChoose)
            {
                isChoose = true;
                UIManager.Instance.GetUIWindow<MainUIWindow>().ShutAndOpen(false);
                UIManager.Instance.GetUIWindow<ChooseUIWindow>().player1Choices[0].sprite = player1choice[0];
                UIManager.Instance.GetUIWindow<ChooseUIWindow>().player1Choices[1].sprite = player1choice[1];
                UIManager.Instance.GetUIWindow<ChooseUIWindow>().player2Choices[0].sprite = player2choice[0];
                UIManager.Instance.GetUIWindow<ChooseUIWindow>().player2Choices[1].sprite = player2choice[1];
                UIManager.Instance.GetUIWindow<ChooseUIWindow>().ShutAndOpen(true);
                UIManager.Instance.GetUIWindow<ChooseUIWindow>().choice += EventChoice;
            }
        }
    }
}

