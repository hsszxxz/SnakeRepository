using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using attack;
using injure;
namespace enemy
{
    ///<summary>
    ///
    ///<summary>
    public interface IInitable
    {
        void enemyInit();
    }
    public abstract class EnemyBase: MonoBehaviour,IInitable,IAttack,IGetInjured,IDead,ISkillRelease
    {
        [Tooltip("最大血量")]
        public int maxBlood;
        [HideInInspector]
        public int blood;
        [Tooltip("怪碰到哪些tag的碰撞体会受到伤害")]
        public List<string> colliderHurtTags ;
        protected SpriteRenderer spriteRenderer;
        [HideInInspector]
        public Transform targetSneak
        {
            get
            {
                return FindSneakPosition.FindTarget(transform);
            }
        }
        protected virtual void GetAttacked()
        {
            blood -= 1;
            if (blood <= 0)
            {
                Death();
            }
            else if (gameObject.activeSelf)
            {
                StartCoroutine(LightAgain());
            }
        }
        protected virtual void Death()
        {
            GameObjectPool.Instance.CollectObject(gameObject);
            EnemyManager.Instance.enemyTransform.Remove(transform);
        }
        protected void GeneralDeath()
        {
            GameObjectPool.Instance.CollectObject(gameObject);
            EnemyManager.Instance.enemyTransform.Remove(transform);
        }
        protected IEnumerator  LightAgain()
        {
            spriteRenderer.color = Color.red;
            yield return new WaitForSeconds(0.2f);
            spriteRenderer.color = Color.white;
        }
        protected virtual void Start()
        {
            blood = maxBlood;
            spriteRenderer = GetComponent<SpriteRenderer>();
        }
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (colliderHurtTags.Contains(collision.transform.tag))
            {
               GetAttacked();
            }
        }

        public virtual void enemyInit()
        {
            blood = maxBlood;
        }

        public abstract void Attack();

        public abstract void GetInjured();

        public abstract void Dead();

        public abstract void Release();

        public abstract void OnEnterAttack();
    }
}

