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
    public class EnemyBoss2Base : EnemyBase
    {
        private  BloodUIWindow bloodUIWindow;
        public Sprite bloodBackSprite;

        [Tooltip("��ʣ����Ѫʱ������׶�")]
        public float secondBlood;
        [Tooltip("���׶ν�ս��������")]
        public float secondDis;
        [Tooltip("���׶ι������")]
        public float secondSpace;
        private bool isSecond = true;
        private FollowPlayer followPlayer;
        private BulletConfig bulletConfig;

        [Tooltip("������ٿ�ʼ��ս")]
        public float distance;
        [Tooltip("�������빥��һ��")]
        public float spaceTime;
        private float currentTime;

        public Animator animator;
        private Animator boss2;

        public GameObject boss2Detect;
        IEnumerator LateCloseAnima()
        {
            yield return new WaitForSeconds(0.4f);
            boss2.SetBool("BaoZha", false);
        }
        IEnumerator LateCloseAnima2()
        {
            yield return new WaitForSeconds(0.6f);
            animator.SetBool("Detect", false);
        }
        protected override void Start()
        {
            base.Start();
            bloodUIWindow = UIManager.Instance.GetUIWindow<BloodUIWindow>();
            boss2 = GetComponent<Animator>();
            enemyInit();
        }

        public override void enemyInit()
        {
            base.enemyInit();
            followPlayer = GetComponent<FollowPlayer>();
            bulletConfig = GetComponent<BulletConfig>();
            isSecond = true;
            bulletConfig.enabled = false;
            followPlayer.PathFindingComponentControl(false);
        }



        public override void Attack()
        {
            boss2.SetBool("Start", true);
            bloodUIWindow.BloodLineChange(blood, maxBlood);
            currentTime += Time.deltaTime;
            if (isSecond && currentTime < spaceTime && spaceTime - currentTime < 0.8f)
            {
                animator.SetBool("Detect", true);
                StartCoroutine(LateCloseAnima2());
            }
            if (currentTime >= spaceTime)
            {
                if (isSecond)
                {
                    boss2.SetBool("BaoZha", true);
                    StartCoroutine(LateCloseAnima());
                }
                if (Vector2.Distance(transform.position, targetSneak.position) <= distance && currentTime >= spaceTime)
                {
                    currentTime = 0;
                    EventSystemCenter.Instance.EventTrigger("playerInjure");
                }
            }
        }

        public override void GetInjured()
        {
            blood -= 1;
            if (blood == 12)
            {
                GameObjectPool.Instance.CreateObject("food", Resources.Load("Prefabs/Food") as GameObject, transform.position + new Vector3(0, 4, 0), Quaternion.identity);
                GameObjectPool.Instance.CreateObject("food", Resources.Load("Prefabs/Food") as GameObject, transform.position + new Vector3(0, -4, 0), Quaternion.identity);
                GameObjectPool.Instance.CreateObject("food", Resources.Load("Prefabs/Food") as GameObject, transform.position + new Vector3(4, 0, 0), Quaternion.identity);
                GameObjectPool.Instance.CreateObject("food", Resources.Load("Prefabs/Food") as GameObject, transform.position + new Vector3(-4, 0, 0), Quaternion.identity);
            }
            else if (blood <= secondBlood && isSecond)
            {
                isSecond = false;
                boss2Detect.SetActive(false);
                followPlayer.PathFindingComponentControl(false);
                distance = secondDis;
                spaceTime = secondSpace;
                bulletConfig.enabled = true;
            }
            StartCoroutine(LightAgain());
        }

        public override void Dead()
        {
            EnemyManager.Instance.bossDic.Remove("boss2");
            EnemyManager.Instance.enemyDebate[1] = true;
            FungusController.Instance.StartBlock("Boss2��");
            bloodUIWindow.ShutAndOpen(false);
        }

        public override void Release()
        {
        }

        public override void OnEnterAttack()
        {
            boss2Detect.SetActive(true);
            followPlayer.PathFindingComponentControl(true);
            FungusController.Instance.StartBlock("Boss2ǰ");
            bloodUIWindow.ShutAndOpen(true);
            bloodUIWindow.bloodBack.sprite = bloodBackSprite;
        }
    }
}

