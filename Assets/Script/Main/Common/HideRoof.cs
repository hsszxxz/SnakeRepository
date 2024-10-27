using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
public class HideRoof : MonoBehaviour
{
    public Vector2 minPos;
    public Vector2 maxPos;
    private Transform target;
    private void Start()
    {
        target = FindSneakPosition.FindTarget(transform);
    }
    private void Update()
    {
        if (target==null)
        {
            target = FindSneakPosition.FindTarget(transform);
        }
        else
        {
            if (target.position.x >=minPos.x && target.position.x <= maxPos.x && target.position.y >= minPos.y && target.position.y <= maxPos.y )
            {
                gameObject.SetActive(false);
            }
            else
            {
                gameObject.SetActive(true);
            }
        }
    }
}

