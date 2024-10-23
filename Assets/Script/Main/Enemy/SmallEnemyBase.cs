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
        protected override void Start()
        {
            base.Start();
            rigid = GetComponent<Rigidbody2D>();
            followPlayer = GetComponent<FollowPlayer>();
        }
        public void ShakeEnemyBack(Transform shakeFrom, float backForce)
        {
            Vector3 dir = (transform.position - shakeFrom.position).normalized;
            followPlayer.PathFindingComponentControl(false);
            rigid.AddForce(dir * backForce, ForceMode2D.Impulse);
            StartCoroutine(followPlayer.OpenPathFindingComponet());
        }
    }
}

