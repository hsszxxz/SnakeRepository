using control;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class LateLoadGame : MonoBehaviour
{
    [HideInInspector]
    public InputDevice[] headDevices;
    private void Start()
    {
        headDevices = new InputDevice[2];
    }
}

