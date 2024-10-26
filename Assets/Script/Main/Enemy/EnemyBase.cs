using bullet;
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
        private SpriteRenderer spriteRenderer;
        [HideInInspector]
        public Transform targetSneak
        {
            get
            {
                if (target==null)
                {
                    target = FindSneakPosition.FindTarget(transform);
                }
                return target;
            }
        }
        private Transform target;
        private void GetAttacked()
        {
            if (gameObject.activeSelf)
            {
                StartCoroutine(LightAgain());
            }
            GotInjured();
        }
        IEnumerator  LightAgain()
        {
            spriteRenderer.color = Color.red;
            yield return new WaitForSeconds(0.2f);
            spriteRenderer.color = Color.white;
        }
        protected virtual void GotInjured()
        {
            blood -= 1;
            if (blood <= 0)
            {
                GameObjectPool.Instance.CollectObject(gameObject);
                GameObjectPool.Instance.CreateObject("food", Resources.Load("Prefabs/Food") as GameObject, transform.position, Quaternion.identity);
            }
        }
        protected virtual void Start()
        {
            blood = maxBlood;
            spriteRenderer = GetComponent<SpriteRenderer>();
            EventSystemCenter.Instance.AddEventListener("enemyInjure", GetAttacked);
        }
        public virtual void EnemyInit()
        {
            blood = maxBlood;
        }
        protected virtual void OnCollisionEnter2D(Collision2D collision)
        {
            if (colliderHurtTags.Contains(collision.transform.tag))
            {
                EventSystemCenter.Instance.EventTrigger("enemyInjure");
            }
        }
    }
}

