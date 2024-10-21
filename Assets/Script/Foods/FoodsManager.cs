using System.Collections.Generic;
using UnityEngine;

public class FoodsManager : MonoBehaviour
{
    [Tooltip("生成位置的x，y最小值")]
    public List<Vector2> minPoints = new List<Vector2>();
    [Tooltip("生成位置的x，y最大值")]
    public List<Vector2> maxPoints = new List<Vector2>();
    [Tooltip("每一片区域生成多少物体")]
    public List<int> foodNum = new List<int>();
    private void Start()
    {
        if (!GenerateMethod.InitRandomObject(foodNum, minPoints, maxPoints, "Prefabs/Food", "food"))
        {
            Debug.LogError("food生成错误");
        }
    }
}

