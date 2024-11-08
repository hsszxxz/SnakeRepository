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
            SaveSystemManager.Instance.SaveObject(data, index);
        }
        private static void LoadEnemyBoss(int index)
        {
            BossData bossData = SaveSystemManager.Instance.LoadObject<BossData>(index);
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
            SaveSystemManager.Instance.SaveObject(bagData,index);
        }
        private static void LoadBag(int index)
        {
            BagData data = SaveSystemManager.Instance.LoadObject<BagData>(index);
            ItemManager.Instance.CleanAllItems();
            foreach ( Vector2 temp in data.items )
            {
                ItemManager.Instance.AddObject((int)temp.x, (int)temp.y);
            }
        }
        public static void DeleteSave(int index)
        {
           SaveSystemManager.Instance.DeleteSaveItem(index);
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
            SaveSystemManager.Instance.SaveObject(sneakDate, index);
        }
        private static void LoadSnake(int index)
        {
            GameObject snake = SneakManager.Instance.sneakBodies;
            SnakeObjectData snakeObjectData = SaveSystemManager.Instance.LoadObject<SnakeObjectData>(index);
            snake.transform.position = snakeObjectData.position;
            SneakManager.Instance.InitHeads();
            SneakManager.Instance.head1.transform.position = snakeObjectData.head1position;
            for (int i = 0;i<snakeObjectData.sneakBodyLength;i++)
            {
                SneakManager.Instance.AddSneakBodyToPrevious(SneakManager.Instance.head1.GetComponent<SneakBody>());
            }
        }


        //[MenuItem("developer/delete player data prefs")]
        //public static void DeletPlayerDataPrefs()
        //{
        //    SaveSystemManager.Instance.DeleteAll();
        //}
    }
}
