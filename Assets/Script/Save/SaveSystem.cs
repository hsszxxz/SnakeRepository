using sneak;
using Unity.VisualScripting;
using UnityEngine;
namespace save
{
    ///<summary>
    ///
    ///<summary>
    public static class SaveSystem
    {
        [System.Serializable]
        class ObjectData
        {
            public string name;
            public Vector3 position;
            public Quaternion rotation;
            public Vector3 scale;
        }
        [System.Serializable]
        class SnakeObjectData : ObjectData
        {
            public int sneakBodyLength;
            public Vector3 head1position;
        }
        public static void SaveSnake()
        {
            GameObject snake = SneakManager.Instance.sneakBodies;
            Vector3 position = new Vector3(0,1000,0);
            foreach (Transform child in snake.transform)
            {
                if (child.position.y < position.y)
                    position = child.position;
            }
            var sneakDate = new SnakeObjectData()
            {
                position = position,
                sneakBodyLength = SneakManager.Instance.length,
                head1position = SneakManager.Instance.head1.transform.position,
            };
            SavePlayerPrefs("snake", sneakDate);
        }
        public static void LoadSnake()
        {
            GameObject snake = SneakManager.Instance.sneakBodies;
            SnakeObjectData snakeObjectData = LoadFromPlayerPrefs<SnakeObjectData>("snake");
            snake.transform.position = snakeObjectData.position;
            SneakManager.Instance.InitHeads();
            SneakManager.Instance.head1.transform.position = snakeObjectData.head1position;
            for (int i = 0;i<snakeObjectData.sneakBodyLength;i++)
            {
                SneakManager.Instance.AddSneakBodyToPrevious(SneakManager.Instance.head1.GetComponent<SneakBody>());
            }
        }
        public static void SavePlayerPrefs(string key, object data)
        {
            var json =JsonUtility.ToJson(data);
            PlayerPrefs.SetString(key, json);
            PlayerPrefs.Save();
        }
        public static T LoadFromPlayerPrefs<T>(string key)
        {
            var json = PlayerPrefs.GetString(key, null);
            return JsonUtility.FromJson<T>(json);
        }
        [UnityEditor.MenuItem("Developer/Delete Player Data Prefs")]
        public static void DeletPlayerDataPrefs()
        {
            PlayerPrefs.DeleteAll();
        }
    }
}

