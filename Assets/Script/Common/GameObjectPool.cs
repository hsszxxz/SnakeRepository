using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
public interface IResetable
{
    void OnReset();
}
public class GameObjectPool : MonoSingleton<GameObjectPool>
{
    private Dictionary<string, List<GameObject>> cahe;
    public override void Init()
    {
        base.Init();
        cahe = new Dictionary<string, List<GameObject>>();
    }
    public GameObject CreateObject(string key, GameObject prefab, Vector3 pos, Quaternion quaternion)
    {
        GameObject go = FindUsableObject(key);
        if (go == null)
        {
            go = AddObject(key, prefab);
        }
        UseObject(pos, quaternion, go);
        return go;
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="go">���ն���</param>
    /// <param name="delay">�ӳ�</param>
    public void CollectObject(GameObject go, float delay = 0)
    {
        StartCoroutine(CollectObjectDelay(go, delay));
    }
    //���
    //һ������ǵ������
    public void Clear(string key)
    {
        if (cahe.ContainsKey(key))
        {
            foreach (GameObject go in cahe[key])
            {
                Destroy(go);
            }
            cahe.Remove(key);
        }
    }

    public void ClearAll()
    {
        foreach (List<GameObject> go in cahe.Values)
        {
            foreach (GameObject go1 in go)
            {
                Destroy(go1);
            }
        }
        cahe.Clear();
    }
    private IEnumerator CollectObjectDelay(GameObject go, float delay)
    {
        yield return new WaitForSeconds(delay);
        go.SetActive(false);
    }
    private static void UseObject(Vector3 pos, Quaternion quaternion, GameObject go)
    {
        go.transform.position = pos;
        go.transform.rotation = quaternion;
        go.SetActive(true);
        foreach (var item in go.GetComponents<IResetable>())
        {
            item.OnReset();
        }
    }

    private GameObject AddObject(string key, GameObject prefab)
    {
        GameObject go = Instantiate(prefab);
        if (!cahe.ContainsKey(key))
            cahe.Add(key, new List<GameObject>());
        cahe[key].Add(go);
        return go;
    }

    private GameObject FindUsableObject(string key)
    {
        if (cahe.ContainsKey(key))
            return cahe[key].Find(g => !g.activeInHierarchy);
        return null;
    }
}

