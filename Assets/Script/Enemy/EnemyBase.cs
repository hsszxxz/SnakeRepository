using Pathfinding;
using sneak;
using System.Collections;
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
        private void Start()
        {
            destinationSetter = GetComponent<AIDestinationSetter>();
            seeker = GetComponent<Seeker>();
            aipath = GetComponent<AIPath>();
            rigid = GetComponent<Rigidbody2D>();
            destinationSetter.target = RandomTarget();
        }
        private Transform RandomTarget()
        {
            int randomIndex = Random.Range(1, 2);
            return SneakManager.Instance.bodies[randomIndex].transform;
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
    }
}

