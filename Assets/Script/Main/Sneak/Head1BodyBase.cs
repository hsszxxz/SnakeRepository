using attack;
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
    public class Head1BodyBase : SneakBody,IGetInjured,IEatFood,ISkillRelease,IMovable
    {
        [HideInInspector]
        public KeyBoardMotorControl motorControl;
        public float moveForce;
        public Color shineColor;
        public SectorArea area = new SectorArea();
        public SectorBackSkill backSkill = new SectorBackSkill();
        public SectorTransforThingToAnother toAnother = new SectorTransforThingToAnother();
        public GameObject skillArea;
        private Coroutine light;
        protected override void Init()
        {
            type = HeadType.Head1;
            motorControl = new KeyBoardMotorControl(KeyBoardKit.WASD, transform, moveForce);
            transform.tag = "Head1";
            area.Init(transform);
            backSkill.Init(transform,area);
            toAnother.Init(transform,area);
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

        public void GetInjured()
        {
            if (light == null)
            {
                SneakManager.Instance.DeletSneakBody(SneakManager.Instance.bodies[2]);
                light = StartCoroutine(LightAgain());
            }
        }

        public void Eat(Food food)
        {
            SneakManager.Instance.AddSneakBodyToPrevious(this);
            GameObjectPool.Instance.CollectObject(food.gameObject);
        }

        public void Release()
        {
            if (Input.GetKeyUp(KeyCode.E))
            {
                backSkill.Release();
                toAnother.Release();
                skillArea.SetActive(false);
            }
            if (Input.GetKey(KeyCode.E))
            {
                skillArea.SetActive(true);
            }
        }

        public void ObjectMove()
        {
            motorControl.MoveControl();
        }
    }
}

