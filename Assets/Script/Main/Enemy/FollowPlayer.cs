using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace enemy
{
    ///<summary>
    ///
    ///<summary>
    [RequireComponent(typeof(EnemyBase))]
    public class FollowPlayer : MonoBehaviour
    {
        private AIDestinationSetter destinationSetter;
        private Seeker seeker;
        private AIPath aipath;

        private EnemyBase enemyBase;
        private void Start()
        {
            destinationSetter = GetComponent<AIDestinationSetter>();
            seeker = GetComponent<Seeker>();
            aipath = GetComponent<AIPath>();
            enemyBase = GetComponent<EnemyBase>();
            destinationSetter.target = enemyBase.FindTarget();
        }
        public IEnumerator OpenPathFindingComponet()
        {
            yield return new WaitForSeconds(1);
            PathFindingComponentControl(true);
        }
        public void PathFindingComponentControl(bool flag)
        {
            aipath.enabled = flag;
            seeker.enabled = flag;
            destinationSetter.enabled = flag;
        }
    }
}

