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
        private void Start()
        {
            rigid = GetComponent<Rigidbody2D>();
            followPlayer = GetComponent<FollowPlayer>();
            blood = maxBlood;
        }
        public void ShakeEnemyBack(Transform shakeFrom, float backForce)
        {
            Vector3 dir = (transform.position - shakeFrom.position).normalized;
            followPlayer.PathFindingComponentControl(false);
            rigid.AddForce(dir * backForce, ForceMode2D.Impulse);
            StartCoroutine(followPlayer.OpenPathFindingComponet());
        }
        private void OnDisable()
        {
            if (!Application.isPlaying)
            {
                GameObjectPool.Instance.CreateObject("food", Resources.Load("Prefabs/Food") as GameObject, transform.position, Quaternion.identity);
            }
        }
    }
}

