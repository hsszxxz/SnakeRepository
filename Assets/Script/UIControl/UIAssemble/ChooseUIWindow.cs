using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class ChooseUIWindow : UIWindow
{
    public List<Text> player1Choices;
    public List<Text> player2Choices;
    public float chooseTime;

    public Image timeLine;

    private int player1index = 0;
    private int player2index = 0;

    private float currentTime;
    public override void ShutAndOpen(bool flag)
    {
        base.ShutAndOpen(flag);
        if (flag)
            StartCoroutine(ChooseText());
    }
    private void TimeLineChange(float fic)
    {
        timeLine.fillAmount = fic;
    }
    private void PlayerChoose(int player,int change)
    {
        if (player==1)
        {
            player1index = (player1index + player1Choices.Count + change) % player1Choices.Count;
        }
        if (player==2)
        {
            player2index = (player2index+ player2Choices.Count + change) % player2Choices.Count;
        }
    }
    IEnumerator ChooseText()
    {
        while(currentTime <= chooseTime)
        {
            chooseTime += Time.deltaTime;
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                PlayerChoose(2, -1);
            }
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                PlayerChoose(2, 1);
            }
            if (Input.GetKeyDown(KeyCode.W))
            {
                PlayerChoose(1, -1);
            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                PlayerChoose(1, 1);
            }
            TimeLineChange((chooseTime-currentTime)/chooseTime);
            yield return null;
        }
    }
}

