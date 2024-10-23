using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
namespace enemy
{
    ///<summary>
    ///
    ///<summary>
    public class EnemyManager : MonoSingleton<EnemyManager>
    {
        [Tooltip("��ս����λ�õ�x��y��Сֵ")]
        public List<Vector2> nearMinPoints = new List<Vector2>();
        [Tooltip("��ս����λ�õ�x��y���ֵ")]
        public List<Vector2> nearMaxPoints = new List<Vector2>();
        [Tooltip("��սÿһƬ���ɶ��ٸ�")]
        public List<int> nearEnemyNum = new List<int>();

        [Tooltip("Զ������λ�õ�x��y��Сֵ")]
        public List<Vector2> remoteMinPoints = new List<Vector2>();
        [Tooltip("Զ������λ�õ�x��y���ֵ")]
        public List<Vector2> remoteMaxPoints = new List<Vector2>();
        [Tooltip("Զ��ÿһƬ���ɶ��ٸ�")]
        public List<int> remoteEnemyNum = new List<int>();

        [Tooltip("��һ��Boss����λ��")]
        public Vector3 enemyBoss1Position;
        [Tooltip("�ڶ���Boss����λ��")]
        public Vector3 enemyBoss2Position;

        [HideInInspector]
        public Dictionary<string,EnemyBase> bossDic = new Dictionary<string,EnemyBase>();
        [HideInInspector]
        public List<bool> enemyDebate = new List<bool>{ false, false };
        private void Start()
        {
            if (!GenerateMethod.InitRandomObject(nearEnemyNum, nearMinPoints, nearMaxPoints, "Prefabs/Enemy", "enemy"))
            {
                Debug.LogError("enemy���ɴ���");
            }
            if (!GenerateMethod.InitRandomObject(remoteEnemyNum, remoteMinPoints, remoteMaxPoints, "Prefabs/EnemyRemote", "enemyremote"))
            {
                Debug.LogError("enemy���ɴ���");
            }
            GameObject boss1 =Instantiate(Resources.Load("Prefabs/enemyBoss1") as GameObject);
            boss1.transform.position = enemyBoss1Position;
            bossDic.Add("boss1",boss1.GetComponent<EnemyBase>());
            GameObject boss2 = Instantiate(Resources.Load("Prefabs/enemyBoss2") as GameObject);
            boss2.transform.position = enemyBoss2Position;
            bossDic.Add("boss2", boss2.GetComponent<EnemyBase>());
        }
        public void BossInit(List<bool>debate)
        {
            if (!debate[0])
            {
                bossDic["boss1"].EnemyInit();
                bossDic["boss1"].gameObject.transform.position = enemyBoss1Position;
            }
            if (!debate[1])
            {
                bossDic["boss2"].EnemyInit();
                bossDic["boss2"].gameObject.transform.position = enemyBoss2Position;
            }
        }
    }

}

