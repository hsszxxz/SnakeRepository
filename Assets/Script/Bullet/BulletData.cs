using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace bullet
{
    ///<summary>
    ///
    ///<summary>
    [CreateAssetMenu(menuName =("BulletData"))]
    public class BulletData : ScriptableObject
    {
        public GameObject prafabs;
        [Tooltip("��ʼλ��ƫ����")]
        public Vector3 P_Offset = Vector3.zero;//��ʼλ��ƫ����
        [Tooltip("��ʼ��תƫ����")]
        public Vector3 R_Offset = Vector3.zero;//��ʼ��תƫ����
        [Tooltip("����������")]
        public int Count = 1;//����������
        [Tooltip("�ӵ����ʱ��")]
        public float cdTime = 0.1f;//�ӵ����ʱ��
        [Tooltip("�ӵ��ƶ��ٶ�")]
        public float speed = 10;//�ӵ��ƶ��ٶ�
        [Tooltip("�����ӵ���ĽǶ�")]
        public float angle = 0;//�����ӵ���ĽǶ�
        [Tooltip("�����ӵ���ľ���")]
        public float distance = 0;//�����ӵ���ľ���
        [Tooltip("�뷢���ľ���")]
        public float centerDis = 0;//�뷢���ľ���
        [Tooltip("��ת���ٶ�")]
        public float selfRotate = 0;//��ת���ٶ�
        [HideInInspector]
        public float tempShootTime;//��һ�η���ʱ��
        public Quaternion tempRotation;
        public void ResetTempData(Transform center)
        {
            tempShootTime = 0;
            tempRotation = center.rotation;
        }
    }
}

