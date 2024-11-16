using attack;
using control;
using Fungus;
using injure;
using move;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph;
using UnityEngine;
using UnityEngine.Rendering.Universal;
namespace sneak
{
    ///<summary>
    ///头1的基本信息
    ///<summary>
    public class Head2BodyBase : SneakBody,IAttack,ISkillRelease,IMovable
    {
        [HideInInspector]
        public InputControl inputControl;
        public float moveForce;

        public Color shineColor;
        public BulletAttack bulletAttack = new BulletAttack();
        private Coroutine light;
        protected override void Init()
        {
            type = HeadType.Head2;
            inputControl = new InputControl(InputDevice.KeyBoard, transform, HeadType.Head2);
            transform.tag = "Head2";
            bulletAttack.Init(transform);
        }
        IEnumerator LightAgain()
        {
            foreach (SneakBody body in SneakManager.Instance.bodies)
            {
                body.spriteRenderer.color = shineColor;
            }
            yield return new WaitForSeconds(0.2f);
            foreach (SneakBody body in SneakManager.Instance.bodies)
            {
                body.spriteRenderer.color = Color.white;
            }
            light = null;
        }


        public void Release()
        {
           return;
        }

        public void Attack()
        {
            Vector3 bulletDir = inputControl.BulletAttackButton();
            if (bulletDir.z!=-1.1f)
            {
                if (SneakManager.Instance.bodies.Count <= 2)
                    Debug.Log("No bullet");
                else
                {
                    SneakManager.Instance.DeletSneakBody(SneakManager.Instance.bodies[2]);
                    bulletAttack.targetPos = bulletDir;
                    bulletAttack.Attack();
                }
            }
            //    if (Input.GetMouseButtonUp(1))
            //{
            //    if (Time.timeScale != 0)
            //    {
            //        if (SneakManager.Instance.bodies.Count <= 2)
            //            Debug.Log("No bullet");
            //        else
            //        {
            //            SneakManager.Instance.DeletSneakBody(SneakManager.Instance.bodies[2]);
            //            bulletAttack.targetPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //            bulletAttack.Attack();
            //        }
            //    }
            //}
        }

        public void ObjectMove()
        {
            inputControl.Move(moveForce);
        }

        public void OnEnterAttack() { }
    }
}

