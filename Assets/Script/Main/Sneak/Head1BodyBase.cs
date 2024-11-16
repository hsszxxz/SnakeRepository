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
    public class Head1BodyBase : SneakBody,IGetInjured,IEatFood,ISkillRelease,IMovable
    {
        [HideInInspector]
        public InputControl inputControl;
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
            inputControl = new InputControl(InputDevice.KeyBoard,transform,HeadType.Head1);
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
            if (inputControl.SkillButtonCancel())
            {
                backSkill.Release();
                toAnother.Release();
                skillArea.SetActive(false);
            }
            if (inputControl.SkillButtonPress())
            {
                skillArea.SetActive(true);
            }
        }

        public void ObjectMove()
        {
            inputControl.Move(moveForce);
        }
    }
}

