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
        protected BloodUIWindow bloodUIWindow;
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
        public Animator boss2;

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
        }
        //private void EnterAttackMethod()
        //{
        //    boss2Detect.SetActive(true);
        //    nearAttack.isBoss2First = true;
        //    followPlayer.PathFindingComponentControl(true);
        //}
        public override void enemyInit()
        {
            base.enemyInit();
            followPlayer = GetComponent<FollowPlayer>();
            bulletConfig = GetComponent<BulletConfig>();
            isSecond = true;
            boss2Detect.SetActive(true);
            bulletConfig.enabled = false;
            followPlayer.PathFindingComponentControl(false);
        }
        private void OnDeath()
        {
            EnemyManager.Instance.bossDic.Remove("boss2");
            EnemyManager.Instance.enemyDebate[1] = true;
            FungusController.Instance.StartBlock("Boss2��");
        }
        //private void GotInjured(int currentBlood)
        //{
        //    if (currentBlood==12)
        //    {
        //        GameObjectPool.Instance.CreateObject("food",Resources.Load("Prefabs/Food") as GameObject,transform.position+ new Vector3(0,4,0),Quaternion.identity);
        //        GameObjectPool.Instance.CreateObject("food", Resources.Load("Prefabs/Food") as GameObject, transform.position + new Vector3(0, -4, 0), Quaternion.identity);
        //        GameObjectPool.Instance.CreateObject("food", Resources.Load("Prefabs/Food") as GameObject, transform.position + new Vector3(4, 0, 0), Quaternion.identity);
        //        GameObjectPool.Instance.CreateObject("food", Resources.Load("Prefabs/Food") as GameObject, transform.position + new Vector3(-4, 0, 0), Quaternion.identity);
        //    }
        //    else if (currentBlood <= secondBlood && isSecond)
        //    {
        //        isSecond = false;
        //        nearAttack.isBoss2First = false;
        //        boss2Detect.SetActive(false);
        //        followPlayer.PathFindingComponentControl(false);
        //        nearAttack.distance = secondDis;
        //        nearAttack.spaceTime = secondSpace;
        //        bulletConfig.enabled = true;
        //    }
        //}

        public override void Attack()
        {
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
        }

        public override void Dead()
        {
            EnemyManager.Instance.bossDic.Remove("boss2");
            EnemyManager.Instance.enemyDebate[1] = true;
            FungusController.Instance.StartBlock("Boss2��");
        }

        public override void Release()
        {
            throw new System.NotImplementedException();
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

