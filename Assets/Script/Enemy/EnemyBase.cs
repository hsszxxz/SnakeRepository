using NUnit.Framework;
using Pathfinding;
using sneak;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace enemy
{
    ///<summary>
    ///
    ///<summary>
    public class EnemyBase : MonoBehaviour, IEnemyBackable
    {
        private Rigidbody2D rigid;
        private AIDestinationSetter destinationSetter;
        private Seeker seeker;
        private AIPath aipath;
        [HideInInspector]
        public int blood;
        [Tooltip("怪碰到哪些tag的碰撞体会收到伤害")]
        public List<string> colliderHurtTags ;
        private void Start()
        {
            destinationSetter = GetComponent<AIDestinationSetter>();
            seeker = GetComponent<Seeker>();
            aipath = GetComponent<AIPath>();
            rigid = GetComponent<Rigidbody2D>();
            destinationSetter.target = FindTarget();
        }
        private Transform FindTarget()
        {
            Transform head1Trans = SneakManager.Instance.head1.transform;
            Transform head2Trans = SneakManager.Instance.head2.transform;
            float distance1 = Vector2.Distance(transform.position, head1Trans.position);
            float distance2 = Vector2.Distance(transform.position,head2Trans.position);
            return (distance1 > distance2) ? head2Trans : head1Trans;
        }
        public void ShakeEnemyBack(Transform shakeFrom,float backForce)
        {
            Vector3 dir = (transform.position - shakeFrom.position).normalized;
            PathFindingComponentControl(false);
            rigid.AddForce(dir * backForce,ForceMode2D.Impulse);
            StartCoroutine(OpenPathFindingComponet());
        }
        IEnumerator OpenPathFindingComponet()
        {
            yield return new WaitForSeconds(1);
            PathFindingComponentControl(true);
        }
        private void PathFindingComponentControl(bool flag)
        {
            aipath.enabled = flag;
            seeker.enabled = flag;
            destinationSetter.enabled = flag;
        }
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (colliderHurtTags.Contains(collision.transform.tag))
                blood -= 1;
        }
    }
}

