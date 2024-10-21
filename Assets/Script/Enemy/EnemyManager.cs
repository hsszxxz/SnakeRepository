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
        [Tooltip("��ս����λ�õ�x��y��Сֵ")]
        public List<Vector2> nearMinPoints = new List<Vector2>();
        [Tooltip("��ս����λ�õ�x��y���ֵ")]
        public List<Vector2> nearMaxPoints = new List<Vector2>();
        [Tooltip("��սÿһƬ���ɶ��ٸ�")]
        public List<int> nearEnemyNum = new List<int>();

        [Tooltip("Զ������λ�õ�x��y��Сֵ")]
        public List<Vector2> remoteMinPoints = new List<Vector2>();
        [Tooltip("Զ������λ�õ�x��y���ֵ")]
        public List<Vector2> remoteMaxPoints = new List<Vector2>();
        [Tooltip("Զ��ÿһƬ���ɶ��ٸ�")]
        public List<int> remoteEnemyNum = new List<int>();
        private void Start()
        {
            if (!GenerateMethod.InitRandomObject(nearEnemyNum, nearMinPoints, nearMaxPoints, "Prefabs/Enemy", "enemy"))
            {
                Debug.LogError("enemy���ɴ���");
            }
            if (!GenerateMethod.InitRandomObject(remoteEnemyNum, remoteMinPoints, remoteMaxPoints, "Prefabs/EnemyRemote", "enemyremote"))
            {
                Debug.LogError("enemy���ɴ���");
            }
        }
    }
}

