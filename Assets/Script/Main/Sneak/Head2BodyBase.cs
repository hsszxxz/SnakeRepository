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
    ///头2的基本信息
    ///<summary>
    public class Head2BodyBase : SneakBody,IAttack,ISkillRelease,IMovable
    {
        [HideInInspector]
        public InputControl inputControl;
        public float moveForce;

        public Color shineColor;
        public BulletAttack bulletAttack = new BulletAttack();
        private Coroutine light;
        private LateLoadGame loadGame;
        private BulletDirSHow bulletDirShow;
        protected override void Init()
        {
            bulletDirShow = GetComponentInChildren<BulletDirSHow>(); 
            loadGame = GameObject.Find("DontDestroyGo").GetComponent<LateLoadGame>();
            type = HeadType.Head2;
            inputControl = new InputControl(loadGame.headDevices[1], transform, HeadType.Head2);
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
            if (SneakManager.Instance.bodies.Count > 2 &&inputControl.BulletAttackButton(bulletAttack))
            {
                SneakManager.Instance.DeletSneakBody(SneakManager.Instance.bodies[2]);
            }
            else if (inputControl.BulletAttackButton(bulletAttack))
            {
                Debug.Log("No bullet");
            }
            Vector2 faceDir = inputControl.BulletAttackFaceDirection();
            if (faceDir.x < 0)
            {
                bulletDirShow.angle = Vector2.Angle(new Vector2(0, 1), faceDir);
            }
            else
            {
                bulletDirShow.angle = Vector2.Angle(new Vector2(0, -1), faceDir);
            }
        }

        public void ObjectMove()
        {
            inputControl.Move(moveForce);
        }

        public void OnEnterAttack() { }
    }
}

