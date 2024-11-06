using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
namespace save
{
    /// <summary>
    /// ���ݴ浵�洢�־û�������
    /// </summary>
    public class SaveSystemManager : MonoSingleton<SaveSystemManager>
    {
        private SaveSystemData saveSystemData;//�浵ϵͳ����

        // �浵�ı���
        private const string saveDirName = "saveData";
        // ���õı��棺1.ȫ�����ݵı��棨�ֱ��ʡ��������ã� 2.�浵�����ñ��档
        // ��������£��浵ϵͳ����ά��
        private const string settingDirName = "setting";

        // �浵�ļ���·��
        private string saveDirPath;
        private string settingDirPath;

        // �浵�ж���Ļ����ֵ� 
        // <�浵ID,<�ļ����ƣ�ʵ�ʵĶ���>>
        private Dictionary<int, Dictionary<string, object>> cacheDic = new Dictionary<int, Dictionary<string, object>>();

        #region ��ʼ��
        public override void Init()
        {
            base.Init();
            // �浵�ļ���·��
            saveDirPath = Application.persistentDataPath + "/" + saveDirName;
            settingDirPath = Application.persistentDataPath + "/" + settingDirName;
            Debug.Log("�洢��������ʼ���ɹ�");
            //���·��������Ŀ¼
            CheckAndCreateDir();
            // ��ʼ��SaveSystemData
            InitSaveSystemData();
            // ����浵�����ֵ�
            CleanCache();
        }
        #endregion

        #region ���桢��ȡȫ�����ô浵
        /// <summary>
        /// �������ã�ȫ����Ч�����غ��κ�һ���浵
        /// </summary>
        public T LoadSetting<T>(string fileName) where T : class
        {
            return LoadFile<T>(settingDirPath + "/" + fileName);
        }
        /// <summary>
        /// �������ã�ȫ����Ч�����غ��κ�һ���浵
        /// </summary>
        public T LoadSetting<T>() where T : class
        {
            return LoadSetting<T>(typeof(T).Name);
        }
        /// <summary>
        /// �������ã�ȫ����Ч�����غ��κ�һ���浵
        /// </summary>
        public void SaveSetting(object saveObject, string fileName)
        {
            SaveFile(saveObject, settingDirPath + "/" + fileName);
        }

        /// <summary>
        /// �������ã�ȫ����Ч�����غ��κ�һ���浵
        /// </summary>
        public void SaveSetting(object saveObject)
        {
            SaveSetting(saveObject, saveObject.GetType().Name);
        }

        /// <summary>
        /// ɾ���������ô浵
        /// </summary>
        public void DeleteAllSetting()
        {
            if (Directory.Exists(settingDirPath))
            {
                // ֱ��ɾ��Ŀ¼
                Directory.Delete(settingDirPath, true);
            }
            CheckAndCreateDir();
        }
        #endregion

        #region ��������ȡ��ɾ��ĳһ���û��浵
        /// <summary>
        /// ��ȡSaveItem
        /// </summary>
        public SavePoint GetSaveItem(int id)
        {
            for (int i = 0; i < saveSystemData.saveItemList.Count; i++)
            {
                if (saveSystemData.saveItemList[i].saveID == id)
                {
                    return saveSystemData.saveItemList[i];
                }
            }
            return null;
        }
        /// <summary>
        /// ��ȡSaveItem
        /// </summary>
        public SavePoint GetSaveItem(SavePoint savePoint)
        {
            GetSaveItem(savePoint.saveID);
            return null;
        }

        /// <summary>
        /// ���һ���浵
        /// </summary>
        /// <returns></returns>
        public SavePoint CreateSaveItem()
        {
            saveSystemData.currID += 1;
            SavePoint saveItem = new SavePoint(saveSystemData.currID, DateTime.Now);
            saveSystemData.saveItemList.Add(saveItem);
            // ����SaveSystemData д�����
            UpdateSaveSystemData();
            return saveItem;
        }

        /// <summary>
        /// ɾ���浵
        /// </summary>
        /// <param name="saveID">�浵��ID</param>
        public void DeleteSaveItem(int saveID)
        {
            string itemDir = GetSavePath(saveID, false);
            // ���·������ �� ��Ч
            if (itemDir != null)
            {
                // ������浵�µ��ļ��ݹ�ɾ��
                Directory.Delete(itemDir, true);
            }
            saveSystemData.saveItemList.Remove(GetSaveItem(saveID));
            // �Ƴ�����
            RemoveCache(saveID);
            // ����SaveSystemData д�����
            UpdateSaveSystemData();
        }
        /// <summary>
        /// ɾ���浵
        /// </summary>
        public void DeleteSaveItem(SavePoint saveItem)
        {
            DeleteSaveItem(saveItem.saveID);
        }
        #endregion

        #region ���桢��ȡ��ɾ���û��浵��ĳһ����
        /// <summary>
        /// ���������ĳ���浵��
        /// </summary>
        /// <param name="saveObject">Ҫ����Ķ���</param>
        /// <param name="saveFileName">������ļ�����</param>
        /// <param name="saveID">�浵��ID</param>
        public void SaveObject(object saveObject, string saveFileName, int saveID = 0)
        {
            // �浵���ڵ��ļ���·��
            string dirPath = GetSavePath(saveID, true);
            // ����Ķ���Ҫ�����·��
            string savePath = dirPath + "/" + saveFileName;
            // ����ı���
            SaveFile(saveObject, savePath);
            // ���´浵ʱ��
            GetSaveItem(saveID).UpdateTime(DateTime.Now);
            // ����SaveSystemData д�����
            UpdateSaveSystemData();

            // ���»���
            SetCache(saveID, saveFileName, saveObject);

        }

        /// <summary>
        /// ���������ĳ���浵��
        /// </summary>
        /// <param name="saveObject">Ҫ����Ķ���</param>
        /// <param name="saveFileName">������ļ�����</param>
        public void SaveObject(object saveObject, string saveFileName, SavePoint saveItem)
        {
            SaveObject(saveObject, saveFileName, saveItem.saveID);
        }
        /// <summary>
        /// ���������ĳ���浵��
        /// </summary>
        /// <param name="saveObject">Ҫ����Ķ���</param>
        /// <param name="saveID">�浵��ID</param>
        public void SaveObject(object saveObject, int saveID = 0)
        {
            SaveObject(saveObject, saveObject.GetType().Name, saveID);
        }
        /// <summary>
        /// ���������ĳ���浵��
        /// </summary>
        /// <param name="saveObject">Ҫ����Ķ���</param>
        /// <param name="saveID">�浵��ID</param>
        public void SaveObject(object saveObject, SavePoint saveItem)
        {
            SaveObject(saveObject, saveObject.GetType().Name, saveItem);
        }

        /// <summary>
        /// ��ĳ������Ĵ浵�м���ĳ������
        /// </summary>
        /// <typeparam name="T">Ҫ���ص�ʵ������</typeparam>
        /// <param name="saveFileName">�ļ�����</param>
        /// <param name="id">�浵ID</param>
        public T LoadObject<T>(string saveFileName, int saveID = 0) where T : class
        {
            T obj = GetCache<T>(saveID, saveFileName);
            if (obj == null)
            {
                // �浵���ڵ��ļ���·��
                string dirPath = GetSavePath(saveID);
                if (dirPath == null) return null;
                // ����Ķ���Ҫ�����·��
                string savePath = dirPath + "/" + saveFileName;
                obj = LoadFile<T>(savePath);
                SetCache(saveID, saveFileName, obj);
            }
            return obj;
        }

        /// <summary>
        /// ��ĳ������Ĵ浵�м���ĳ������
        /// </summary>
        /// <typeparam name="T">Ҫ���ص�ʵ������</typeparam>
        /// <param name="saveFileName">�ļ�����</param>
        public T LoadObject<T>(string saveFileName, SavePoint saveItem) where T : class
        {
            return LoadObject<T>(saveFileName, saveItem.saveID);
        }


        /// <summary>
        /// ��ĳ������Ĵ浵�м���ĳ������
        /// </summary>
        /// <typeparam name="T">Ҫ���ص�ʵ������</typeparam>
        /// <param name="id">�浵ID</param>
        public T LoadObject<T>(int saveID = 0) where T : class
        {
            return LoadObject<T>(typeof(T).Name, saveID);
        }

        /// <summary>
        /// ��ĳ������Ĵ浵�м���ĳ������
        /// </summary>
        /// <typeparam name="T">Ҫ���ص�ʵ������</typeparam>
        /// <param name="saveItem">�浵��</param>
        public T LoadObject<T>(SavePoint saveItem) where T : class
        {
            return LoadObject<T>(typeof(T).Name, saveItem.saveID);
        }

        /// <summary>
        /// ɾ��ĳ���浵�е�ĳ������
        /// </summary>
        /// <param name="saveID">�浵��ID</param>
        public void DeleteObject<T>(string saveFileName, int saveID) where T : class
        {
            //��ջ����ж���
            if (GetCache<T>(saveID, saveFileName) != null)
            {
                RemoveCache(saveID, saveFileName);
            }
            // �浵�������ڵ��ļ�·��
            string dirPath = GetSavePath(saveID);
            string savePath = dirPath + "/" + saveFileName;
            //ɾ����Ӧ���ļ�
            File.Delete(savePath);

        }

        /// <summary>
        /// ɾ��ĳ���浵�е�ĳ������
        /// </summary>
        /// <param name="saveID">�浵��ID</param>
        public void DeleteObject<T>(string saveFileName, SavePoint saveItem) where T : class
        {
            DeleteObject<T>(saveFileName, saveItem.saveID);
        }

        /// <summary>
        /// ɾ��ĳ���浵�е�ĳ������
        /// </summary>
        /// <param name="saveID">�浵��ID</param>
        public void DeleteObject<T>(int saveID) where T : class
        {
            DeleteObject<T>(typeof(T).Name, saveID);
        }

        /// <summary>
        /// ɾ��ĳ���浵�е�ĳ������
        /// </summary>
        /// <param name="saveID">�浵��ID</param>
        public void DeleteObject<T>(SavePoint saveItem) where T : class
        {
            DeleteObject<T>(typeof(T).Name, saveItem.saveID);
        }
        #endregion

        #region ��ȡ��ɾ�������û��浵

        /// <summary>
        /// ��ȡ���д浵
        /// ���µ��������
        /// </summary>
        /// <returns></returns>
        public List<SavePoint> GetAllSaveItem()
        {
            return saveSystemData.saveItemList;
        }

        /// <summary>
        /// ��ȡ���д浵
        /// �������µ�����ǰ��
        /// </summary>
        /// <returns></returns>
        public List<SavePoint> GetAllSaveItemByCreatTime()
        {
            List<SavePoint> saveItems = new List<SavePoint>(saveSystemData.saveItemList.Count);

            for (int i = 0; i < saveSystemData.saveItemList.Count; i++)
            {
                saveItems.Add(saveSystemData.saveItemList[saveSystemData.saveItemList.Count - (i + 1)]);
            }
            return saveItems;
        }

        /// <summary>
        /// ��ȡ���д浵
        /// ���¸��µ���������
        /// </summary>
        /// <returns></returns>
        public List<SavePoint> GetAllSaveItemByUpdateTime()
        {
            List<SavePoint> saveItems = new List<SavePoint>(saveSystemData.saveItemList.Count);
            for (int i = 0; i < saveSystemData.saveItemList.Count; i++)
            {
                saveItems.Add(saveSystemData.saveItemList[i]);
            }
            OrderByUpdateTimeComparer orderBy = new OrderByUpdateTimeComparer();
            saveItems.Sort(orderBy);
            return saveItems;
        }

        private class OrderByUpdateTimeComparer : IComparer<SavePoint>
        {
            public int Compare(SavePoint x, SavePoint y)
            {
                if (x.LastSaveTime > y.LastSaveTime)
                {
                    return -1;
                }
                else
                {
                    return 1;
                }
            }
        }

        /// <summary>
        /// ��ȡ���д浵
        /// ���ܽ������
        /// </summary>
        public List<SavePoint> GetAllSaveItem<T>(Func<SavePoint, T> orderFunc, bool isDescending = false)
        {
            if (isDescending)
            {
                return saveSystemData.saveItemList.OrderByDescending(orderFunc).ToList();
            }
            else
            {
                return saveSystemData.saveItemList.OrderBy(orderFunc).ToList();
            }

        }

        /// <summary>
        /// ɾ�������û��浵��Ϣ
        /// </summary>
        public void DeleteAllSaveItem()
        {
            if (Directory.Exists(saveDirPath))
            {
                // ֱ��ɾ��Ŀ¼
                Directory.Delete(saveDirPath, true);
            }
            CheckAndCreateDir();
            InitSaveSystemData();
        }

        /// <summary>
        /// ɾ�����д浵��Ϣ
        /// </summary>
        public void DeleteAll()
        {
            CleanCache();
            DeleteAllSaveItem();
            DeleteAllSetting();
        }
        /// <summary>
        /// �����ǰ�Ĵ浵ID
        /// </summary>
        /// <returns></returns>
        #endregion

        #region ���¡���ȡ��ɾ���û��浵����
        /// <summary>
        /// ���û���
        /// </summary>
        /// <param name="saveID">�浵ID</param>
        /// <param name="fileName">�ļ�����</param>
        /// <param name="saveObject">Ҫ����Ķ���</param>
        private void SetCache(int saveID, string fileName, object saveObject)
        {
            // �����ֵ����Ƿ������SaveID
            if (cacheDic.ContainsKey(saveID))
            {
                // ����浵����û������ļ�
                if (cacheDic[saveID].ContainsKey(fileName))
                {
                    cacheDic[saveID][fileName] = saveObject;
                }
                else
                {
                    cacheDic[saveID].Add(fileName, saveObject);
                }
            }
            else
            {
                cacheDic.Add(saveID, new Dictionary<string, object>() { { fileName, saveObject } });
            }
        }

        /// <summary>
        /// ��ȡ����
        /// </summary>
        /// <param name="saveID">�浵ID</param>
        /// <param name="saveObject">Ҫ����Ķ���</param>
        private T GetCache<T>(int saveID, string fileName) where T : class
        {
            // �����ֵ����Ƿ������SaveID
            if (cacheDic.ContainsKey(saveID))
            {
                // ����浵����û������ļ�
                if (cacheDic[saveID].ContainsKey(fileName))
                {
                    return cacheDic[saveID][fileName] as T;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// �Ƴ�����
        /// </summary>
        private void RemoveCache(int saveID)
        {
            cacheDic.Remove(saveID);
        }

        /// <summary>
        /// �Ƴ������е�ĳһ������
        /// </summary>
        private void RemoveCache(int saveID, string fileName)
        {
            cacheDic[saveID].Remove(fileName);
        }

        /// <summary>
        /// ����浵����
        /// </summary>
        public void CleanCache()
        {
            cacheDic.Clear();
        }
        #endregion

        #region �ڲ����ߺ���
        /// <summary>
        /// ��ȡ�浵ϵͳ����
        /// </summary>
        /// <returns></returns>
        //��ʼ��SaveSystemData�����SavePoint���б�
        private void InitSaveSystemData()
        {
            saveSystemData = LoadFile<SaveSystemData>(saveDirPath + "/SaveSystemData");
            if (saveSystemData == null)
            {
                saveSystemData = new SaveSystemData();
                UpdateSaveSystemData();
            }
        }

        private void UpdateSaveSystemData()
        {
            SaveFile(saveSystemData, saveDirPath + "/SaveSystemData");
        }
        //�����������Ŀ¼
        private void CheckAndCreateDir()
        {
            // ȷ��·���Ĵ���
            if (Directory.Exists(saveDirPath) == false)
            {
                Directory.CreateDirectory(saveDirPath);
            }
            if (Directory.Exists(settingDirPath) == false)
            {
                Directory.CreateDirectory(settingDirPath);
            }
        }

        private string GetSavePath(int saveID, bool createDir = true)
        {
            // ��֤�Ƿ���ĳ���浵
            if (GetSaveItem(saveID) == null) Debug.LogWarning("saveID �浵�����ڣ�");

            string saveDir = saveDirPath + "/" + saveID;
            // ȷ���ļ����Ƿ����
            if (Directory.Exists(saveDir) == false)
            {
                if (createDir)
                {
                    Directory.CreateDirectory(saveDir);
                }
                else
                {
                    return null;
                }
            }

            return saveDir;
        }
        private void SaveFile(object saveObject, string path)
        {
            SaveTool.SaveJson(saveObject, path);
        }

        private T LoadFile<T>(string path) where T : class
        {
            return SaveTool.LoadJson<T>(path);
        }
        #endregion
    }

}

