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
        public List<Vector2> nearMinPoints = new List<Vector2>();
        public List<Vector2> nearMaxPoints = new List<Vector2>();
        public List<int> nearEnemyNum = new List<int>();

        public List<Vector2> remoteMinPoints = new List<Vector2>();
        public List<Vector2> remoteMaxPoints = new List<Vector2>();
        public List<int> remoteEnemyNum = new List<int>();
        private void Start()
        {
            if (!GenerateMethod.InitRandomObject(nearEnemyNum, nearMinPoints, nearMaxPoints, "Prefabs/Enemy", "enemy"))
            {
                Debug.LogError("enemy生成错误");
            }
            if (!GenerateMethod.InitRandomObject(remoteEnemyNum, remoteMinPoints, remoteMaxPoints, "Prefabs/EnemyRemote", "enemyremote"))
            {
                Debug.LogError("enemy生成错误");
            }
        }
    }
}

