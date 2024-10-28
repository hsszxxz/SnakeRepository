using Fungus;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public delegate void EventChoice(int index1,int index2);
public class ChooseUIWindow : UIWindow
{
    public event EventChoice choice;
    public List<Image> player1Choices;
    public List<Image> player2Choices;
    public float chooseTime;

    public Image timeLine;

    private int player1index = 0;
    private int player2index = 0;
    private bool isChoose=false;
    public Image Title;

    private float currentTime;
    public override void ShutAndOpen(bool flag)
    {
        base.ShutAndOpen(flag);
        if (flag)
        {
            currentTime = 0;
            isChoose = false;
            StartCoroutine(ChooseText());
        }
    }
    private void TimeLineChange(float fic)
    {
        timeLine.fillAmount = fic;
    }
    IEnumerator ChooseText()
    {
        while(currentTime <= chooseTime)
        {
            yield return null;
            currentTime += Time.deltaTime;
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                player2Choices[1].gameObject.SetActive(false);
                if (isChoose)
                {
                    break;
                }
                else
                {
                    isChoose=true;
                }
            }
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                player2Choices[0].gameObject.SetActive(false);
                player2index = 1;
                if (isChoose)
                {
                    break;
                }
                else
                {
                    isChoose = true;
                }
            }
            if (Input.GetKeyDown(KeyCode.W))
            {
                player1Choices[1].gameObject.SetActive(false);
                if (isChoose)
                {
                    break;
                }
                else
                {
                    isChoose = true;
                }
            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                player1Choices[0].gameObject.SetActive(false);
                player1index = 1;
                if (isChoose)
                {
                    break;
                }
                else
                {
                    isChoose = true;
                }
            }
            TimeLineChange((float)(chooseTime-currentTime)/chooseTime);
        }
        ShutAndOpen(false);
        choice(player1index,player2index);
        player1Choices[0].gameObject.SetActive(true);
        player1Choices[1].gameObject.SetActive(true);
        player2Choices[1].gameObject.SetActive(true);
        player2Choices[0].gameObject.SetActive(true);
        choice = null;
    }
}

