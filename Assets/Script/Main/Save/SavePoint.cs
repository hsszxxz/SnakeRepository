using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace save
{
    /// <summary>
    /// һ���浵����
    /// </summary>
    [Serializable]
    public class SavePoint
    {
        // �浵ID
        public int saveID;

        // ˽���ֶΣ���󱣴�ʱ��
        private DateTime lastSaveTime;

        // �������ԣ���ȡ��󱣴�ʱ��
        public DateTime LastSaveTime
        {
            get
            {
                // ��� lastSaveTime ��Ĭ��ֵ�����Խ��ַ�������Ϊ DateTime
                if (lastSaveTime == default(DateTime))
                {
                    DateTime.TryParse(lastSaveTimeString, out lastSaveTime);
                }
                return lastSaveTime; // ������󱣴�ʱ��
            }
        }

        // ���ڳ־û����ַ�����Json��֧�� DateTime ����
        [SerializeField] private string lastSaveTimeString;

        // ���캯������ʼ���浵ID����󱣴�ʱ��
        public SavePoint(int saveID, DateTime lastSaveTime)
        {
            this.saveID = saveID; // ���ô浵ID
            this.lastSaveTime = lastSaveTime; // ������󱣴�ʱ��
            lastSaveTimeString = lastSaveTime.ToString(); // �� DateTime ת��Ϊ�ַ���
        }

        // ������󱣴�ʱ��
        public void UpdateTime(DateTime lastSaveTime)
        {
            this.lastSaveTime = lastSaveTime; // ������󱣴�ʱ��
            lastSaveTimeString = lastSaveTime.ToString(); // ���µ� DateTime ת��Ϊ�ַ���
        }
    }

}

