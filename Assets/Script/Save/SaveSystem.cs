using sneak;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
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
        class BagData
        {
            //id是x
            //数量是y
            public List<Vector2 >items = new List<Vector2>();
        }
        public static void SaveBag()
        {
            List<Vector2> itemsValue = new List<Vector2>();
            foreach( ItemScript temp in ItemManager.Instance.datas)
            {
                itemsValue.Add(new Vector2(temp.id, temp.num));
            }
            BagData bagData = new BagData()
            {
                items = itemsValue
            };
            SavePlayerPrefs("bag", bagData);
        }
        public static void LoadBag()
        {
            BagData data = LoadFromPlayerPrefs<BagData>("bag");
            Debug.Log(data.items.Count);
            ItemManager.Instance.CleanAllItems();
            foreach ( Vector2 temp in data.items )
            {
                ItemManager.Instance.AddObject((int)temp.x, (int)temp.y);
            }
        }
        public static void SaveAll()
        {
            SaveBag();
            SaveSnake();
        }
        public static void LoadAll()
        {
            LoadBag();
            LoadSnake();
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
        private static void SavePlayerPrefs(string key, object data)
        {
            var json =JsonUtility.ToJson(data);
            PlayerPrefs.SetString(key, json);
            PlayerPrefs.Save();
        }
        private static T LoadFromPlayerPrefs<T>(string key)
        {
            var json = PlayerPrefs.GetString(key, null);
            return JsonUtility.FromJson<T>(json);
        }
        //[MenuItem("Developer/Delete Player Data Prefs")]
        //public static void DeletPlayerDataPrefs()
        //{
        //    PlayerPrefs.DeleteAll();
        //}
    }
}

