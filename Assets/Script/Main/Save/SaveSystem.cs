using sneak;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using enemy;
using System;
using Pathfinding;
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
        [System.Serializable]
        class BossData
        {
            public List<bool> debateCondition = new List<bool>();
        }
        class BagData
        {
            //id是x
            //数量是y
            public List<Vector2 >items = new List<Vector2>();
        }
        private static void SaveEnemyBoss(int index)
        {
            List<bool> debate = EnemyManager.Instance.enemyDebate;
            BossData data = new BossData()
            {
                debateCondition = debate
            };
            SavePlayerPrefs("boss"+index.ToString(),data);
        }
        private static void LoadEnemyBoss(int index)
        {
            BossData bossData = LoadFromPlayerPrefs<BossData>("boss"+index.ToString());
            EnemyManager.Instance.BossInit(bossData.debateCondition);
        }
        private static void SaveBag(int index)
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
            SavePlayerPrefs("bag"+index.ToString(), bagData);
        }
        private static void LoadBag(int index)
        {
            BagData data = LoadFromPlayerPrefs<BagData>("bag" + index.ToString());
            ItemManager.Instance.CleanAllItems();
            foreach ( Vector2 temp in data.items )
            {
                ItemManager.Instance.AddObject((int)temp.x, (int)temp.y);
            }
        }
        class Index 
        {
            public int index=0;
        };
        public static void SaveIndex(int i)
        {
            Index index1 = new Index()
            {
                index = i
            };
            SavePlayerPrefs("index", index1);
        }
        public static int LoadIndex()
        {
            Index index2 = LoadFromPlayerPrefs<Index>("index");
            if (index2 == null)
                return 0;
            return index2.index;
        }
        public static void DeleteSave(int index)
        {
            PlayerPrefs.DeleteKey("boss"+index.ToString());
            PlayerPrefs.DeleteKey("snake" + index.ToString());
            PlayerPrefs.DeleteKey("bag" + index.ToString());
        }
        public static void SaveAll(int index)
        {
            SaveBag(index);
            SaveSnake(index);
            SaveEnemyBoss(index);
        }
        public static void LoadAll(int index)
        {
            LoadBag(index);
            LoadSnake(index);
            LoadEnemyBoss(index);
            EventSystemCenter.Instance.ClearAllListeners();
        }
        private static void SaveSnake(int index)
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
            SavePlayerPrefs("snake" + index.ToString(), sneakDate);
        }
        private static void LoadSnake(int index)
        {
            GameObject snake = SneakManager.Instance.sneakBodies;
            SnakeObjectData snakeObjectData = LoadFromPlayerPrefs<SnakeObjectData>("snake"+index.ToString());
            snake.transform.position = snakeObjectData.position;
            SneakManager.Instance.InitHeads();
            SneakManager.Instance.head1.transform.position = snakeObjectData.head1position;
            for (int i = 0;i<snakeObjectData.sneakBodyLength;i++)
            {
                SneakManager.Instance.AddSneakBodyToPrevious(SneakManager.Instance.head1.GetComponent<SneakBody>());
            }
            foreach (Transform item in EnemyManager.Instance.enemyTransform)
            {
                item.GetComponent<AIDestinationSetter>().target = SneakManager.Instance.head1.transform;
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
            if (json == string.Empty)
            {
                return default(T);
            }
            else
            {
                return JsonUtility.FromJson<T>(json);
            }
        }
        class SaveItem
        {
            public List<string> items;
        };
        public static void SaveSaveItems(List<string>saveItems)
        {
            SaveItem index1 = new SaveItem()
            {
                items = saveItems
            };
            SavePlayerPrefs("item", index1);
        }
        public static List<string> LoadItems()
        {
            if (PlayerPrefs.HasKey("item"))
            {
                return LoadFromPlayerPrefs<SaveItem>("item").items;
            }
            else
            {
                return null;
            }
        }
        //[MenuItem("Developer/Delete Player Data Prefs")]
        //public static void DeletPlayerDataPrefs()
        //{
        //    PlayerPrefs.DeleteAll();
        //}
    }
}

