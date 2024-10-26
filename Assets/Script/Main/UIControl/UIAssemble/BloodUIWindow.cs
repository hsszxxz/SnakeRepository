using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BloodUIWindow : UIWindow
{
    public Image bloodBack;
    public Image bloodIn;
    public void BloodLineChange(int current , int max)
    {
         bloodIn.fillAmount = 1-(float)(max-current)/max;
    }

}
