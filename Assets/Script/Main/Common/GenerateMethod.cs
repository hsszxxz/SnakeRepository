using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public static class  GenerateMethod
{
    public static bool InitRandomObject(List<int> num,List<Vector2>minPoints,List<Vector2>maxPoints,string PrefabPath,string poolTag)
    {
        if (minPoints.Count != maxPoints.Count || minPoints.Count != num.Count || num.Count != maxPoints.Count)
        {
            return false;
        }
        for (int i = 0; i < num.Count; i++)
        {
            for (int j = 0; j < num[i]; j++)
            {
                Vector2 min = minPoints[i];
                Vector2 max = maxPoints[i];
                Vector3 pos = new Vector3(Random.Range(min.x, max.x), Random.Range(min.y, max.y), 0);
                Transform item =  GameObjectPool.Instance.CreateObject(poolTag, Resources.Load(PrefabPath) as GameObject, pos, Quaternion.identity).transform;
            }
        }
        return true;
    }
}
