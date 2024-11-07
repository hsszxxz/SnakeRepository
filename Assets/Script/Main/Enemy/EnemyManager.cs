using System.Collections;
using System.Collections.Generic;
using System.Reflection.Emit;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
namespace enemy
{
    ///<summary>
    ///
    ///<summary>
    public class EnemyManager : MonoSingleton<EnemyManager>
    {
        [Tooltip("近战生成位置的x，y最小值")]
        public List<Vector2> nearMinPoints = new List<Vector2>();
        [Tooltip("近战生成位置的x，y最大值")]
        public List<Vector2> nearMaxPoints = new List<Vector2>();
        [Tooltip("近战每一片生成多少个")]
        public List<int> nearEnemyNum = new List<int>();

        [Tooltip("远程生成位置的x，y最小值")]
        public List<Vector2> remoteMinPoints = new List<Vector2>();
        [Tooltip("远程生成位置的x，y最大值")]
        public List<Vector2> remoteMaxPoints = new List<Vector2>();
        [Tooltip("远程每一片生成多少个")]
        public List<int> remoteEnemyNum = new List<int>();

        [Tooltip("第一个Boss所在位置")]
        public Vector3 enemyBoss1Position;
        [Tooltip("第二个Boss所在位置")]
        public Vector3 enemyBoss2Position;

        [HideInInspector]
        public Dictionary<string,GameObject> bossDic = new Dictionary<string,GameObject>();
        [HideInInspector]
        public List<bool> enemyDebate;
        [HideInInspector]
        public List<Transform> enemyTransform = new List<Transform>();
        private bool InitRandomEnemy(List<int> num, List<Vector2> minPoints, List<Vector2> maxPoints, string PrefabPath, string poolTag)
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
                    Transform item = GameObjectPool.Instance.CreateObject(poolTag, Resources.Load(PrefabPath) as GameObject, pos, Quaternion.identity).transform;
                    enemyTransform.Add(item);
                }
            }

            return true;
        }
        public void ShutAndOpenEnemy(bool flag)
        {
            foreach (var item in enemyTransform)
            {
                item.gameObject.SetActive(flag);
            }
        }
        public override void Init()
        {
            enemyDebate = new List<bool> { false, false };
            if (!InitRandomEnemy(nearEnemyNum, nearMinPoints, nearMaxPoints, "Prefabs/Enemy", "enemy"))
            {
                Debug.LogError("enemy生成错误");
            }
            if (!InitRandomEnemy(remoteEnemyNum, remoteMinPoints, remoteMaxPoints, "Prefabs/EnemyRemote", "enemyremote"))
            {
                Debug.LogError("enemy生成错误");
            }
            GameObject boss1 =Instantiate(Resources.Load("Prefabs/enemyBoss1") as GameObject);
            boss1.transform.position = enemyBoss1Position;
            enemyTransform.Add(boss1.transform);
            bossDic.Add("boss1",boss1);
            GameObject boss2 = Instantiate(Resources.Load("Prefabs/enemyBoss2") as GameObject);
            boss2.transform.position = enemyBoss2Position;
            enemyTransform.Add(boss2.transform);
            bossDic.Add("boss2", boss2);
        }
        public void BossInit(List<bool>debate)
        {
            if (!debate[0])
            {
                bossDic["boss1"].GetComponent<IInitable>().enemyInit();
                bossDic["boss1"].gameObject.transform.position = enemyBoss1Position;
            }
            if (!debate[1])
            {
                bossDic["boss2"].GetComponent<IInitable>().enemyInit();
                bossDic["boss2"].gameObject.transform.position = enemyBoss2Position;
            }
        }
    }

}

