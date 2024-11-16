using attack;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
namespace enemy
{
    ///<summary>
    ///
    ///<summary>
    public class NearAttackEnemyBase:EnemyBase,IEnemyBackable
    {
        private Rigidbody2D rigid;
        private FollowPlayer followPlayer;
        [Tooltip("距离多少开始近战")]
        public float distance;
        [Tooltip("隔多少秒攻击一次")]
        public float spaceTime;
        private float currentTime;
        protected override void Start()
        {
            base.Start();
            rigid = GetComponent<Rigidbody2D>();
            followPlayer = GetComponent<FollowPlayer>();
            currentTime = 0;
        }
        public override void enemyInit()
        {
            base.enemyInit();
            currentTime = 0;
            spriteRenderer.color = Color.white;
        }
        public void ShakeEnemyBack(Transform shakeFrom, float backForce)
        {
            Vector3 dir = (transform.position - shakeFrom.position).normalized;
            followPlayer.PathFindingComponentControl(false);
            rigid.AddForce(dir * backForce, ForceMode2D.Impulse);
            StartCoroutine(followPlayer.OpenPathFindingComponet());
        }

        public override void Attack()
        {
            currentTime += Time.deltaTime;
            if (Vector2.Distance(transform.position, targetSneak.position) <= distance && currentTime >= spaceTime)
            {
                currentTime = 0;
                EventSystemCenter.Instance.EventTrigger("playerInjure");
            }
        }

        public override void GetInjured()
        {
            blood -= 1;
            StartCoroutine(LightAgain());
        }

        public override void Dead()
        {
            GameObjectPool.Instance.CreateObject("food", Resources.Load("Prefabs/Food") as GameObject, transform.position, Quaternion.identity);
            GeneralDeath();
        }

        public override void Release() { }

        public override void OnEnterAttack() { }
    }
}

