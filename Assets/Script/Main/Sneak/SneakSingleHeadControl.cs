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
    public class SneakSingleHeadControl : SneakBody
    {
        private KeyBoardMotorControl motorControl;
        public HeadType headType;
        public float moveForce;
        public Color shineColor;
        private void Update()
        {
            if (motorControl != null )
            {
                motorControl.MoveControl();
            }
        }


        protected override void Init()
        {
            type = headType;
            if (headType == HeadType.Head2)
            {
                motorControl = new KeyBoardMotorControl(KeyBoardKit.Arrow,transform,moveForce);
            }
            else
            {
                motorControl = new KeyBoardMotorControl(KeyBoardKit.WASD,transform,moveForce);
            }
            transform.tag = headType.ToString();
            EventSystemCenter.Instance.AddEventListener("playerInjure", GetInjuer);
        }
        private void GetInjuer()
        {
            if (SneakManager.Instance.bodies.Count >= 3)
            {
                SneakManager.Instance.DeletSneakBody(SneakManager.Instance.bodies[2]);
            }
            else
            {
                Time.timeScale = 0;
                UIManager.Instance.GetUIWindow<MainUIWindow>().ShutAndOpen(false);
                UIManager.Instance.GetUIWindow<DeadUiWindow>().ShutAndOpen(true);
            }
            StartCoroutine(LightAgain());
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
        }
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if(collision.transform.CompareTag("food"))
            {
                 if (headType == HeadType.Head1)
                {
                    SneakManager.Instance.AddSneakBodyToPrevious(this);
                    GameObjectPool.Instance.CollectObject(collision.gameObject);
                }
            }
            if (collision.transform.CompareTag("enemybullet") || collision.transform.CompareTag("enemy"))
            {
                EventSystemCenter.Instance.EventTrigger("playerInjure");
            }
        }
    }
}

