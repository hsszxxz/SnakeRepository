using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace enemy
{
    ///<summary>
    ///
    ///<summary>
    [Serializable]
    public class GenerateEnemyEgg
    {
        [Tooltip("��������λ�ù���boss�����λ��(�м���λ�þͻ��ж��ٸ���)")]
        public List<Vector3> positionOffset;
        public void Excute(Vector3 bossPos)
        {
            for (int i = 0; i < positionOffset.Count; i++)
            {
                GameObjectPool.Instance.CreateObject("enemyEgg", Resources.Load("Prefabs/EnemyEgg") as GameObject, positionOffset[i] + bossPos, Quaternion.identity).SetActive(true);
            }
        }
    }
}

