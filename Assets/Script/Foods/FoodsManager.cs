using System.Collections.Generic;
using UnityEngine;

public class FoodsManager : MonoBehaviour
{
    [Tooltip("����λ�õ�x��y��Сֵ")]
    public List<Vector2> minPoints = new List<Vector2>();
    [Tooltip("����λ�õ�x��y���ֵ")]
    public List<Vector2> maxPoints = new List<Vector2>();
    [Tooltip("ÿһƬ�������ɶ�������")]
    public List<int> foodNum = new List<int>();
    private void Start()
    {
        if (!GenerateMethod.InitRandomObject(foodNum, minPoints, maxPoints, "Prefabs/Food", "food"))
        {
            Debug.LogError("food���ɴ���");
        }
    }
}

