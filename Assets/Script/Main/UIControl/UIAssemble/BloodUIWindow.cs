using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BloodUIWindow : UIWindow
{
    public Image bloodBack;
    public Image bloodIn;
    public void BloodLineChange(float current , float max)
    {
         bloodIn.fillAmount = (current-max)/max;
    }

}
