using System.Collections.Generic;
using UnityEngine;

public class FoodsManager : MonoBehaviour
{
    public List<Vector2> minPoints = new List<Vector2>();
    public List<Vector2> maxPoints = new List<Vector2>();
    public List<int> foodNum = new List<int>();
    private void Start()
    {
        if (!GenerateMethod.InitRandomObject(foodNum, minPoints, maxPoints, "Prefabs/Food", "food"))
        {
            Debug.LogError("foodÉú³É´íÎó");
        }
    }
}

