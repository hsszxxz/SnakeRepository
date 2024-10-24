using sneak;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
///<summary>
///
///<summary>
public class ItemInGround : MonoBehaviour
{
    public GameObject tiShi;
    public GameObject tiShiPanel;
    private Transform target;
    [Tooltip("距离玩家多少距离弹出提示")]
    public float diatance;
    private void Start()
    {
        target = FindTarget();
    }
    private void Update()
    {
        if (target !=null)
        {
            if (Vector2.Distance(target.position,transform.position)<=diatance)
            {
                tiShi.SetActive(true);
                tiShiPanel.SetActive(true);
            }
            else
            {
                tiShi.SetActive(false);
                tiShiPanel.SetActive(false);
            }
        }
        else
        {
            target = FindTarget();
        }
    }
    private Transform FindTarget()
    {
        Transform head1Trans = SneakManager.Instance.head1.transform;
        Transform head2Trans = SneakManager.Instance.head2.transform;
        float distance1 = Vector2.Distance(transform.position, head1Trans.position);
        float distance2 = Vector2.Distance(transform.position, head2Trans.position);
        return (distance1 > distance2) ? head2Trans : head1Trans;
    }
}

