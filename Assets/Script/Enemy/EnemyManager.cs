using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace enemy
{
    ///<summary>
    ///
    ///<summary>
    public class EnemyManager : MonoBehaviour
    {
        public List<Vector2> minPoints = new List<Vector2>();
        public List<Vector2> maxPoints = new List<Vector2>();
        public List<int> enemyNum = new List<int>();
        private void Start()
        {
            if (!GenerateMethod.InitRandomObject(enemyNum, minPoints, maxPoints, "Prefabs/Enemy", "enemy"))
            {
                Debug.LogError("enemyÉú³É´íÎó");
            }
        }
    }
}

