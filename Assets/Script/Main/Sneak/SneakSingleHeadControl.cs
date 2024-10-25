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
        private SneakMotor sneakMotor= new SneakMotor();
        public HeadType headType;
        private Dictionary<HeadType, List<KeyCode>> keyValuePairs;
        public float moveForce;
        public Color shineColor;
        private void Update()
        {
            HeadMove(headType);
        }

        private void HeadMove(HeadType headType)
        {
            for (int i = 0; i < keyValuePairs[headType].Count; i++)
            {
                if (Input.GetKey(keyValuePairs[headType][i]))
                {
                    sneakMotor.SneakMove((Direction)i,moveForce);
                }
            }
        }

        protected override void Init()
        {
            sneakMotor.InitMotor(this);
            keyValuePairs = new Dictionary<HeadType, List<KeyCode>>()
            {
                { HeadType.Head2,new List<KeyCode>(){KeyCode.UpArrow,KeyCode.DownArrow,KeyCode.LeftArrow,KeyCode.RightArrow}},
                 { HeadType.Head1,new List<KeyCode>(){KeyCode.W,KeyCode.S,KeyCode.A,KeyCode.D}},
            };
            type = headType;
            transform.tag = headType.ToString();
            if (headType == HeadType.Head2)
            {
                EventSystemCenter.Instance.AddEventListener("playerInjure", GetInjuer);
            }
        }
        private void GetInjuer()
        {
            if (SneakManager.Instance.bodies.Count >= 3)
            {
                Debug.Log(gameObject);
                SneakManager.Instance.DeletSneakBody(SneakManager.Instance.bodies[2]);
            }
            else
            {
                Debug.LogError("ƒ„À¿¡À");
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
            if (collision.transform.CompareTag("enemybullet"))
            {
                EventSystemCenter.Instance.EventTrigger("playerInjure");
            }
        }
    }
}

