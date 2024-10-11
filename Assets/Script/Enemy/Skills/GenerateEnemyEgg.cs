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
        public Vector3 possitionOffset;
        public int num;
        public void Excute(Vector3 bossPos)
        {
            for (int i = 0; i < num; i++)
            {
                GameObjectPool.Instance.CreateObject("enemyEgg", Resources.Load("Prefabs/EnemyEgg") as GameObject, possitionOffset + bossPos, Quaternion.identity);
            }
        }
    }
}

