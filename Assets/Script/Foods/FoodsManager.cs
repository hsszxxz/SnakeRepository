using System.Collections.Generic;
using UnityEngine;

public class FoodsManager : MonoBehaviour
{
    public List<Vector2> minPoints = new List<Vector2>();
    public List<Vector2> maxPoints = new List<Vector2>();
    public List<int> foodNum = new List<int>();
    private void Start()
    {
        if (minPoints.Count!=maxPoints.Count || minPoints.Count != foodNum.Count || foodNum.Count != maxPoints.Count)
        {
            Debug.LogError("foodÉú³É´íÎó");
        }
        else
        {
            InitRandomFood();
        }
    }
    private void InitRandomFood()
    {
        for (int i =0;i < foodNum.Count;i++)
        {
            for (int j = 0; j < foodNum[i]; j++)
            {
                Vector3 pos = GenerateRandomPos(minPoints[i], maxPoints[i]);
                GameObjectPool.Instance.CreateObject("food", Resources.Load("Prefabs/Food") as GameObject, pos,Quaternion.identity);
            }
        }
    }
    private Vector3 GenerateRandomPos(Vector2 min, Vector2 max)
    {
        float x = Random.Range(min.x, max.x);
        float y = Random.Range(min.y, max.y);
        return new Vector3(x, y, 0);
    }
}

