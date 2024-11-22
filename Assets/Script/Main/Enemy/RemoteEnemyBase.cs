using attack;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;
namespace enemy
{
    ///<summary>
    ///
    ///<summary>
    public class RemoteEnemyBase: EnemyBase,IEnemyBackable
    {
        private Rigidbody2D rigid;
        private FollowPlayer followPlayer;
        [Tooltip("子弹攻击方法")]
        public BulletAttack bulletAttack;
        [Tooltip("隔玩家多少距离开始攻击")]
        public float distance;
        [Tooltip("隔多少时间攻击一次")]
        public float spaceTime;
        private float nowTime;
        protected override void Start()
        {
            base.Start();
            rigid = GetComponent<Rigidbody2D>();
            followPlayer = GetComponent<FollowPlayer>();
        }
        public override void enemyInit()
        {
            base.enemyInit();
            nowTime = 0;
            bulletAttack.Init(transform);
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
            nowTime += Time.deltaTime;
            if (Vector3.Distance(targetSneak.position, transform.position) <= distance)
            {
                if (nowTime > spaceTime)
                {
                    nowTime = 0;
                    bulletAttack.targetPos = targetSneak.position;
                    bulletAttack.Attack();
                }
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

