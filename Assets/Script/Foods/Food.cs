using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Food : MonoBehaviour
{
    private void Awake()
    {
        transform.tag = "food";
    }
}
