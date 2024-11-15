using enemy;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(EnemyControl))]
public class Boss2Animator : MonoBehaviour
{
    private Animator animator;
    EnemyControl boos;
    private void Start()
    {
        boos = GetComponent<EnemyControl>();
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        animator.SetBool("Start", boos.currentState==EnemyState.Attack);
    }
}

