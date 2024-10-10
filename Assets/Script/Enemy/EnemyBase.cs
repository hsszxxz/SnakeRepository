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
        private void Start()
        {
            destinationSetter = GetComponent<AIDestinationSetter>();
            rigid = GetComponent<Rigidbody2D>();
            destinationSetter.target = RandomTarget();
        }
        private Transform RandomTarget()
        {
            int randomIndex = Random.Range(0, 2);
            return SneakManager.Instance.bodies[randomIndex].transform;
        }
        public void ShakeEnemyBack(Transform shakeFrom,float backForce)
        {
            Vector3 dir = (transform.position - shakeFrom.position).normalized;
            rigid.AddForce(dir * backForce, ForceMode2D.Impulse);
        }
    }
}

