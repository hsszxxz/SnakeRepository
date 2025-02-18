using attack;
using injure;
using move;
using save;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
namespace sneak
{
    ///<summary>
    ///
    ///<summary>
    public enum HeadType
    {
        Head1,
        Head2,
        Body
    }
    [RequireComponent(typeof(SneakBody))]
    public class SneakSingleHeadControl : MonoBehaviour
    {
        private IAttack attack;
        private ISkillRelease skill;
        private IGetInjured getInjured;
        private IEatFood getFood;
        private IMovable move;
        private void Start()
        {
            attack = GetComponent<IAttack>();
            skill = GetComponent<ISkillRelease>();
            getInjured = GetComponent<IGetInjured>();
            getFood = GetComponent<IEatFood>();
            move = GetComponent<IMovable>();
            EventSystemCenter.Instance.AddEventListener("playerInjure", Injure);
        }
        private void Update()
        {
            if (attack != null )
            {
                attack.Attack();
            }
            if ( skill != null )
            {
                skill.Release();
            }
            if (move != null)
            {
                move.ObjectMove();
            }
        }
        private void Injure()
        {
            if (SneakManager.Instance.bodies.Count >= 3 && getInjured != null)
            {
                getInjured.GetInjured();
            }
            else if (SneakManager.Instance.bodies.Count < 3)
            {
                Dead();
            }
        }
        private void Dead()
        {
            Time.timeScale = 0;
            UIManager.Instance.GetUIWindow<MainUIWindow>().ShutAndOpen(false);
            UIManager.Instance.GetUIWindow<DeadUiWindow>().ShutAndOpen(true);
        }
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if(collision.transform.CompareTag("food"))
            {
                 if (getFood!=null)
                {
                    getFood.Eat(collision.transform.GetComponent<Food>());
                }
            }
            if (collision.transform.CompareTag("enemybullet") || collision.transform.CompareTag("enemy"))
            {
                EventSystemCenter.Instance.EventTrigger("playerInjure");
                IDead dead = collision.gameObject.GetComponent<IDead>();
                if (dead != null)
                {
                    collision.gameObject.GetComponent<IDead>();
                }
                else
                {
                    GameObjectPool.Instance.CollectObject(collision.gameObject);
                }
            }
        }
    }
}

