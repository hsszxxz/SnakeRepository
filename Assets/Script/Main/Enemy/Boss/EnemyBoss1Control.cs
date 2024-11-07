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
    [RequireComponent(typeof(EnemyBoosBase))]
    public class EnemyBoss1Control:MonoBehaviour
    {
        [Tooltip("在多少血之后产生怪物蛋")]
        public int eggBlood;
        [Tooltip("关于生成蛋的变量")]
        public GenerateEnemyEgg generateEnemyEgg;
        private bool isEgg = true;
        private GameObject key;
        private BulletConfig bulletConfig;
        private EnemyBoosBase boosBase;

        private void Start()
        {
            key = GameObject.Find("8钥匙");
            key.SetActive(false);
            bulletConfig = GetComponent<BulletConfig>();
            boosBase = GetComponent<EnemyBoosBase>();
            boosBase.OnEnterAttack += EnterAttackMethod;
            boosBase.OnGetAttacked += GotInjured;
            boosBase.OnDeath += OnDeath;
            boosBase.OnEnemyInit += enemyInit;
        }
        private void EnterAttackMethod()
        {
            bulletConfig.enabled = true;
        }
        private void enemyInit()
        {
            bulletConfig.enabled = false;
            isEgg = true;
        }
        private void OnDeath()
        {
            EnemyManager.Instance.bossDic.Remove("boss1");
            EnemyManager.Instance.enemyDebate[0] = true;
            key.gameObject.SetActive(true);
            key.transform.position = transform.position;
        }
        private void GotInjured(int currentBlood)
        {
            if (currentBlood <= eggBlood && isEgg)
            {
                generateEnemyEgg.Excute(transform.position);
                isEgg = false;
            }
        }
    }
}

