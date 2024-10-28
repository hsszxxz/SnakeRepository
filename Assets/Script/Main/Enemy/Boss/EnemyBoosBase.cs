using bullet;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace enemy
{
    ///<summary>
    ///
    ///<summary>
    public class EnemyBoosBase:EnemyBase
    {
        [Tooltip("玩家距离boss多少距离时开启弹幕")]
        public float attackDetectDis;
        protected BulletConfig bulletConfig;
        public bool isAttack = false;
        protected BloodUIWindow bloodUIWindow;
        public Sprite bloodBackSprite;
        protected string enmeyInjureName;
        protected bool isboss1Chat = false;
        protected bool isboss2Chat = false;
        public GameObject boss2Detect;
        protected override void Start()
        {
            base.Start();
            bloodUIWindow = UIManager.Instance.GetUIWindow<BloodUIWindow>();
            bulletConfig = GetComponent<BulletConfig>();
            EventSystemCenter.Instance.AddEventListener(enemyInjureName, GetAttacked);
        }
        public override void EnemyInit()
        {
            base.EnemyInit();
            bulletConfig.enabled = false;
            isAttack = false;
            isboss1Chat = false;
            isboss2Chat = false;
    }
        private void Update()
        {
            if (Vector2.Distance(transform.position, targetSneak.position) <= attackDetectDis && !isAttack)
            {
                if (enemyInjureName == "enemyInjure1")
                {
                    bulletConfig.enabled = true;
                    if (!isboss1Chat)
                    {
                        isboss1Chat = true;
                        FungusController.Instance.StartBlock("Boss1前");
                    }
                }
                else if (!isboss2Chat)
                {
                    isboss2Chat = true;
                    boss2Detect.SetActive(true);
                    GetComponent<NearAttack>().isBoss2First = true;
                    GetComponent<FollowPlayer>().PathFindingComponentControl(true);
                    FungusController.Instance.StartBlock("Boss2前");
                }
                isAttack = true;
                bloodUIWindow.ShutAndOpen(true);
                bloodUIWindow.bloodBack.sprite = bloodBackSprite;
            }
            if (isAttack)
            {
                bloodUIWindow.BloodLineChange(blood, maxBlood);
            }
        }
        private void GetAttacked()
        {
            if (gameObject.activeSelf)
            {
                StartCoroutine(LightAgain());
            }
            GotInjured();
        }
        IEnumerator LightAgain()
        {
            spriteRenderer.color = Color.red;
            yield return null;
            spriteRenderer.color = Color.white;
        }
        protected virtual void GotInjured() { }
        protected override void OnCollisionEnter2D(Collision2D collision)
        {
            if (colliderHurtTags.Contains(collision.transform.tag))
            {
                EventSystemCenter.Instance.EventTrigger(enemyInjureName);
            }
        }
    }
}

