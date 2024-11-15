using bullet;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace enemy
{
    ///<summary>
    ///
    ///<summary>
    public delegate void EnterAttack();
    public delegate void GetAttacked(int currentBlood);
    public delegate void Death();
    public delegate void EnemyInit();
    public class EnemyBoosBase:EnemyBase
    {
        [Tooltip("玩家距离boss多少距离时进入攻击状态")]
        public float attackDetectDis;
        protected BloodUIWindow bloodUIWindow;
        public Sprite bloodBackSprite;
        [Tooltip("Boss1前/Boss2前")]
        public string enemyBlockName;

        [HideInInspector]
        public EnemyState currentState = EnemyState.Standby;

        public event EnterAttack onEnterAttack;
        public event GetAttacked OnGetAttacked;
        public event Death OnDeath;
        public event EnemyInit OnEnemyInit;

        protected override void Start()
        {
            base.Start();
            bloodUIWindow = UIManager.Instance.GetUIWindow<BloodUIWindow>();
        }
        private void Update()
        {
            if (Vector2.Distance(transform.position, targetSneak.position) <= attackDetectDis && currentState == EnemyState.Standby)
            {
                OnEnterAttack();
                FungusController.Instance.StartBlock(enemyBlockName);
                currentState = EnemyState.Attack;
                bloodUIWindow.ShutAndOpen(true);
                bloodUIWindow.bloodBack.sprite = bloodBackSprite;
            }
            if (currentState== EnemyState.Attack)
            {
                bloodUIWindow.BloodLineChange(blood, maxBlood);
            }
        }
        protected override void GetAttacked()
        {
            if (currentState == EnemyState.Attack)
            {
                base.GetAttacked();
                OnGetAttacked(blood);
            }
        }
        protected override void Death()
        {
            base.Death();
            bloodUIWindow.ShutAndOpen(false);
            OnDeath();
        }

        public override void enemyInit()
        {
            base.enemyInit();
            OnEnemyInit();
            currentState = EnemyState.Standby;
        }

        public override void Attack()
        {
            if (Vector2.Distance(transform.position, targetSneak.position) <= attackDetectDis && currentState == EnemyState.Standby)
            {
                OnEnterAttack();
                FungusController.Instance.StartBlock(enemyBlockName);
                currentState = EnemyState.Attack;
                bloodUIWindow.ShutAndOpen(true);
                bloodUIWindow.bloodBack.sprite = bloodBackSprite;
            }
            if (currentState == EnemyState.Attack)
            {
                bloodUIWindow.BloodLineChange(blood, maxBlood);
            }
        }

        public override void GetInjured()
        {
            if (currentState == EnemyState.Attack)
            {
                base.GetAttacked();
                OnGetAttacked(blood);
            }
        }

        public override void Dead()
        {
            GeneralDeath();
            bloodUIWindow.ShutAndOpen(false);
            OnDeath();
        }

        public override void Release() { }

        public override void OnEnterAttack()
        {
            throw new System.NotImplementedException();
        }
    }
}

