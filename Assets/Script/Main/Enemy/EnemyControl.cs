using attack;
using injure;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
namespace enemy
{
    public enum EnemyState
    {
        Standby,
        Attack,
        Chat
    }
    ///<summary>
    ///
    ///<summary>
    [RequireComponent(typeof(EnemyBase))]
    public class EnemyControl:MonoBehaviour
    {
        [Tooltip("玩家距离敌人多少距离时进入攻击状态")]
        public float attackDetectDis;
        [HideInInspector]
        public EnemyState currentState = EnemyState.Standby;

        private IInitable enemyInit;
        private IAttack enemyAttack;
        private IGetInjured enemyGetInjured;
        private IDead enemyDead;
        private ISkillRelease enemySkillRelease;
        private EnemyBase enemyBase;

        private void Start()
        {
            enemyBase = GetComponent<EnemyBase>();
            enemyAttack =GetComponent<IAttack>();
            enemyGetInjured = GetComponent<IGetInjured>();
            enemyDead = GetComponent<IDead>();
            enemySkillRelease = GetComponent<ISkillRelease>();
            enemyInit = GetComponent<IInitable>();
        }
        private void Update()
        {
            if (Vector2.Distance(transform.position, enemyBase.targetSneak.position) <= attackDetectDis && currentState == EnemyState.Standby)
            {
                if (enemyAttack != null)
                {
                    enemyAttack.OnEnterAttack();
                }
                currentState = EnemyState.Attack;
            }
            if (currentState == EnemyState.Attack)
            {
                if (enemyAttack != null)
                {
                    enemyAttack.Attack();
                }
                if (enemySkillRelease != null)
                {
                    enemySkillRelease.Release();
                }
            }
        }
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (enemyBase.colliderHurtTags.Contains(collision.transform.tag)&&currentState==EnemyState.Attack)
            {
                if (enemyBase.blood == 1)
                {
                    if (enemyDead != null)
                    {
                        enemyDead.Dead();
                    }
                }
                else
                {
                    if (enemyGetInjured != null)
                    {
                        enemyGetInjured.GetInjured();
                    }
                }
            }
        }
    }
}

