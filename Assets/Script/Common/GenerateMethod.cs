using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GenerateMethod : MonoSingleton<GenerateMethod>
{
    private Vector3 GenerateRandomPos(Vector2 min, Vector2 max)
    {
        float x = Random.Range(min.x, max.x);
        float y = Random.Range(min.y, max.y);
        return new Vector3(x, y, 0);
    }
    public bool InitRandomObject(List<int> num,List<Vector2>minPoints,List<Vector2>maxPoints,string PrefabPath,string poolTag)
    {
        if (minPoints.Count != maxPoints.Count || minPoints.Count != num.Count || num.Count != maxPoints.Count)
        {
            return false;
        }
        for (int i = 0; i < num.Count; i++)
        {
            for (int j = 0; j < num[i]; j++)
            {
                Vector3 pos = GenerateRandomPos(minPoints[i], maxPoints[i]);
                GameObjectPool.Instance.CreateObject(poolTag, Resources.Load(PrefabPath) as GameObject, pos, Quaternion.identity);
            }
        }
        return true;
    }
}
