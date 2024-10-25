using bullet;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace enemy
{
    ///<summary>
    ///
    ///<summary>
    public class EnemyBossBase1 : EnemyBase
    {
        [Tooltip("在多少血之后产生怪物蛋")]
        public int eggBlood;
        [Tooltip("关于生成蛋的变量")]
        public GenerateEnemyEgg generateEnemyEgg;
        private bool isEgg = true;
        [Tooltip("玩家距离boss多少距离时开启弹幕")]
        public float attackDetectDis;
        private BulletConfig bulletConfig;
        private bool isAttack = false;
        private BloodUIWindow bloodUIWindow;
        public Sprite bloodBackSprite;
        protected override void Start()
        {
            base.Start();
            bulletConfig =GetComponent<BulletConfig>();
            bloodUIWindow = UIManager.Instance.GetUIWindow<BloodUIWindow>();
        }
        public override void EnemyInit()
        {
            base.EnemyInit();
            isEgg = true;
            bulletConfig.enabled = false;
            isAttack = false;
        }
        private void Update()
        {
            if ( Vector2.Distance(transform.position,targetSneak.position)<=attackDetectDis )
            {
                if (!isAttack)
                {
                    bulletConfig.enabled = true;
                    isAttack = true;
                    bloodUIWindow.ShutAndOpen(true);
                    bloodUIWindow.bloodBack.sprite = bloodBackSprite;
                }
            }
            if (isAttack)
            {
                bloodUIWindow.BloodLineChange(blood,maxBlood);
            }
        }
        protected override void GotInjured()
        {
            blood -= 1;
            if (blood <= eggBlood && isEgg)
            {
                generateEnemyEgg.Excute(transform.position);
                isEgg = false;
            }
            if (blood <= 0)
            {
                EnemyManager.Instance.bossDic.Remove("boss1");
                EnemyManager.Instance.enemyDebate[0] = true;
                Destroy(gameObject);
            }
        }
    }
}

