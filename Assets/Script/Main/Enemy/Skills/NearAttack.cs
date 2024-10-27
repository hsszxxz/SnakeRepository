using sneak;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace enemy
{
    ///<summary>
    ///
    ///<summary>
    [RequireComponent(typeof(EnemyBase))]
    public class NearAttack : MonoBehaviour
    {
        [Tooltip("距离多少开始近战")]
        public float distance;
        [Tooltip("隔多少秒攻击一次")]
        public float spaceTime;
        private float currentTime;
        private EnemyBase enemyBase;
        [HideInInspector]
        public bool isBoss2First = false;
        public Animator animator;
        public Animator boss2;
        private void Start ()
        {
            enemyBase = GetComponent<EnemyBase>();
            currentTime = 0;
        }
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
        private void Update ()
        {
            currentTime += Time.deltaTime;
            if (isBoss2First &&currentTime < spaceTime && spaceTime - currentTime < 0.8f)
            {
                animator.SetBool("Detect", true);
                StartCoroutine(LateCloseAnima2());
            }
            if (Vector2.Distance(transform.position, enemyBase.targetSneak.position) <= distance && currentTime >= spaceTime)
            {
                if (isBoss2First)
                {
                    boss2.SetBool("BaoZha", true);
                    StartCoroutine(LateCloseAnima());
                }
                currentTime = 0;
                EventSystemCenter.Instance.EventTrigger("playerInjure");
            }
            
        }
    }
}

