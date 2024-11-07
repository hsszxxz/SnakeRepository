using enemy;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(EnemyBoosBase))]
public class Boss2Animator : MonoBehaviour
{
    private Animator animator;
    EnemyBoosBase boos;
    private void Start()
    {
        boos = GetComponent<EnemyBoosBase>();
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        animator.SetBool("Start", boos.currentState==EnemyState.Attack);
    }
}

