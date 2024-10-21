using NUnit.Framework;
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
    public class EnemyBase : MonoBehaviour
    {
        [Tooltip("最大血量")]
        public int maxBlood;
        [HideInInspector]
        public int blood;
        [Tooltip("怪碰到哪些tag的碰撞体会受到伤害")]
        public List<string> colliderHurtTags ;
        private void Start()
        {
            blood = maxBlood;
        }
        public Transform FindTarget()
        {
            Transform head1Trans = SneakManager.Instance.head1.transform;
            Transform head2Trans = SneakManager.Instance.head2.transform;
            float distance1 = Vector2.Distance(transform.position, head1Trans.position);
            float distance2 = Vector2.Distance(transform.position,head2Trans.position);
            return (distance1 > distance2) ? head2Trans : head1Trans;
        }
        protected virtual void OnCollisionEnter2D(Collision2D collision)
        {
            if (colliderHurtTags.Contains(collision.transform.tag))
            {
                blood -= 1;
                if (blood <= 0)
                {
                    GameObjectPool.Instance.CollectObject(gameObject);
                }
            }
        }
    }
}

