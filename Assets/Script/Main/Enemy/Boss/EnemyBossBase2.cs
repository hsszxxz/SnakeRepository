using bullet;
using enemy;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace enemy
{
    ///<summary>
    ///
    ///<summary>
    public class EnemyBossBase2 : EnemyBase
    {
        [Tooltip("��ʣ����Ѫʱ������׶�")]
        public float secondBlood;
        [Tooltip("���׶ν�ս��������")]
        public float secondDis;
        [Tooltip("���׶ι������")]
        public float secondSpace;
        private bool isSecond = true;
        [Tooltip("��Ҿ���boss���پ���ʱ������Ļ")]
        public float attackDetectDis;
        private BulletConfig bulletConfig;
        private bool isAttack = false;
        private BloodUIWindow bloodUIWindow;
        public Sprite bloodBackSprite;
        protected override void Start()
        {
            base.Start();
            bloodUIWindow = UIManager.Instance.GetUIWindow<BloodUIWindow>();
            bulletConfig = GetComponent<BulletConfig>();
        }
        public override void EnemyInit()
        {
            base.EnemyInit();
            isSecond = true;
            bulletConfig.enabled = false;
            isAttack = false;
        }
        private void Update()
        {
            if (Vector2.Distance(transform.position, targetSneak.position) <= attackDetectDis && !isAttack)
            {
                isAttack = true;
                bloodUIWindow.ShutAndOpen(true);
                bloodUIWindow.bloodBack.sprite = bloodBackSprite;
            }
            if (isAttack)
            {
                bloodUIWindow.BloodLineChange(blood, maxBlood);
            }
        }
        protected override void GotInjured()
        {
            blood -= 1;
            if (blood <= 0)
            {
                EnemyManager.Instance.bossDic.Remove("boss2");
                EnemyManager.Instance.enemyDebate[1] = true;
                bloodUIWindow.ShutAndOpen(false);
                Destroy(gameObject);
            }
            else if (blood <= secondBlood && isSecond)
            {
                isSecond = false;
                GetComponent<FollowPlayer>().PathFindingComponentControl(false);
                GetComponent<NearAttack>().distance = secondDis;
                GetComponent<NearAttack>().spaceTime = secondSpace;
                bulletConfig.enabled = true;
            }
        }
    }
}

