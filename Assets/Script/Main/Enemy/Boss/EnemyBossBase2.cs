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
    [RequireComponent(typeof(EnemyBoosBase))]
    public class EnemyBoss2Control :MonoBehaviour
    {
        [Tooltip("还剩多少血时进入二阶段")]
        public float secondBlood;
        [Tooltip("二阶段近战攻击距离")]
        public float secondDis;
        [Tooltip("二阶段攻击间隔")]
        public float secondSpace;
        private bool isSecond = true;
        private NearAttack nearAttack;
        private FollowPlayer followPlayer;
        private EnemyBoosBase boosBase;
        private BulletConfig bulletConfig;

        public GameObject boss2Detect;
        private void Start()
        {
            nearAttack = GetComponent<NearAttack>();
            followPlayer = GetComponent<FollowPlayer>();
            followPlayer.PathFindingComponentControl(false);
            bulletConfig = GetComponent<BulletConfig>();
            boosBase = GetComponent<EnemyBoosBase>();

            boosBase.OnEnterAttack += EnterAttackMethod;
            boosBase.OnGetAttacked += GotInjured;
            boosBase.OnDeath += OnDeath;
            boosBase.OnEnemyInit += enemyInit;
        }
        private void EnterAttackMethod()
        {
            boss2Detect.SetActive(true);
            nearAttack.isBoss2First = true;
            followPlayer.PathFindingComponentControl(true);
        }
        private void enemyInit()
        {
            isSecond = true;
            boss2Detect.SetActive(true);
            bulletConfig.enabled = false;
            followPlayer.PathFindingComponentControl(false);
            nearAttack.isBoss2First = false;
        }
        private void OnDeath()
        {
            EnemyManager.Instance.bossDic.Remove("boss2");
            EnemyManager.Instance.enemyDebate[1] = true;
            FungusController.Instance.StartBlock("Boss2后");
        }
        private void GotInjured(int currentBlood)
        {
            if (currentBlood==12)
            {
                GameObjectPool.Instance.CreateObject("food",Resources.Load("Prefabs/Food") as GameObject,transform.position+ new Vector3(0,4,0),Quaternion.identity);
                GameObjectPool.Instance.CreateObject("food", Resources.Load("Prefabs/Food") as GameObject, transform.position + new Vector3(0, -4, 0), Quaternion.identity);
                GameObjectPool.Instance.CreateObject("food", Resources.Load("Prefabs/Food") as GameObject, transform.position + new Vector3(4, 0, 0), Quaternion.identity);
                GameObjectPool.Instance.CreateObject("food", Resources.Load("Prefabs/Food") as GameObject, transform.position + new Vector3(-4, 0, 0), Quaternion.identity);
            }
            else if (currentBlood <= secondBlood && isSecond)
            {
                isSecond = false;
                nearAttack.isBoss2First = false;
                boss2Detect.SetActive(false);
                followPlayer.PathFindingComponentControl(false);
                nearAttack.distance = secondDis;
                nearAttack.spaceTime = secondSpace;
                bulletConfig.enabled = true;
            }
        }
    }
}

