using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Boss2Choice : MonoBehaviour
{
    public List<Sprite> player1choice;
    public List<Sprite> player2choice;
    public Sprite title;
    public void EventBossChoice(int index1, int index2)
    {
        if (index1 == 0 && index2 == 0)
        {
            FungusController.Instance.StartBlock("end2");
        }
        else if (index1 ==1 && index2 == 1)
        {
            FungusController.Instance.StartBlock("end1");
        }
        else
        {
            FungusController.Instance.StartBlock("end3");
        }
    }
    public void ChooseMethod()
    {
        UIManager.Instance.GetUIWindow<MainUIWindow>().ShutAndOpen(false);
        UIManager.Instance.GetUIWindow<ChooseUIWindow>().player1Choices[0].sprite = player1choice[0];
        UIManager.Instance.GetUIWindow<ChooseUIWindow>().player1Choices[1].sprite = player1choice[1];
        UIManager.Instance.GetUIWindow<ChooseUIWindow>().player2Choices[0].sprite = player2choice[0];
        UIManager.Instance.GetUIWindow<ChooseUIWindow>().player2Choices[1].sprite = player2choice[1];

        UIManager.Instance.GetComponent<ChooseUIWindow>().Title.sprite = title;
        UIManager.Instance.GetUIWindow<ChooseUIWindow>().ShutAndOpen(true);
        UIManager.Instance.GetUIWindow<ChooseUIWindow>().choice += EventBossChoice;
    }
}

