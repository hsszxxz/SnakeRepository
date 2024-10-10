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
        public Vector3 P_Offset = Vector3.zero;//��ʼλ��ƫ����
        public Vector3 R_Offset = Vector3.zero;//��ʼ��תƫ����
        public int Count = 1;//����������
        public float cdTime = 0.1f;//�ӵ����ʱ��
        public float speed = 10;//�ӵ��ƶ��ٶ�
        public float angle = 0;//�����ӵ���ĽǶ�
        public float distance = 0;//�����ӵ���ľ���
        public float centerDis = 0;//�뷢���ľ���
        public float selfRotate = 0;//��ת���ٶ�

        public float tempShootTime;//��һ�η���ʱ��
        public Quaternion tempRotation;
        public void ResetTempData(Transform center)
        {
            tempShootTime = 0;
            tempRotation = center.rotation;
        }
    }
}

