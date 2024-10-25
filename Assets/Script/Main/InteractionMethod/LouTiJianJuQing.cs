using sneak;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class LouTiJianJuQing : MonoBehaviour
{
    public float distacne;
    private Transform target;
    private void Start()
    {
        target  = FindSneakPosition.FindTarget(transform);
    }

    private void Update()
    {
        if (target == null)
        {
            target = FindSneakPosition.FindTarget(transform);
        }
        else
        {
            if (Vector2.Distance(transform.position, target.position)<=distacne)
            {
                UIManager.Instance.GetUIWindow<ChooseUIWindow>().ShutAndOpen(true);
            }
        }
    }
}

