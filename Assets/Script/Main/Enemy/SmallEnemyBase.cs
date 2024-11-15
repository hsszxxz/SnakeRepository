using attack;
using Pathfinding;
using sneak;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace enemy
{
    ///<summary>
    ///
    ///<summary>
    public class SmallEnemyBase :EnemyBase,IEnemyBackable
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
        public override void enemyInit()
        {
            base.enemyInit();
            rigid = GetComponent<Rigidbody2D>();
            followPlayer = GetComponent<FollowPlayer>();
            bulletAttack.Init(transform);
            nowTime = 0;
        }
        public void ShakeEnemyBack(Transform shakeFrom, float backForce)
        {
            Vector3 dir = (transform.position - shakeFrom.position).normalized;
            followPlayer.PathFindingComponentControl(false);
            rigid.AddForce(dir * backForce, ForceMode2D.Impulse);
            StartCoroutine(followPlayer.OpenPathFindingComponet());
        }
        protected override void Death()
        {
            GameObjectPool.Instance.CreateObject("food", Resources.Load("Prefabs/Food") as GameObject, transform.position, Quaternion.identity);
            base.Death();
        }

        public override void Attack()
        {
            
        }

        public override void GetInjured()
        {
            throw new System.NotImplementedException();
        }

        public override void Dead()
        {
            throw new System.NotImplementedException();
        }

        public override void Release()
        {
            throw new System.NotImplementedException();
        }

        public override void OnEnterAttack()
        {
            throw new System.NotImplementedException();
        }
    }
}

