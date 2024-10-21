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
        [Tooltip("初始位置偏移量")]
        public Vector3 P_Offset = Vector3.zero;//初始位置偏移量
        [Tooltip("初始旋转偏移量")]
        public Vector3 R_Offset = Vector3.zero;//初始旋转偏移量
        [Tooltip("弹道的数量")]
        public int Count = 1;//弹道的数量
        [Tooltip("子弹间隔时间")]
        public float cdTime = 0.1f;//子弹间隔时间
        [Tooltip("子弹移动速度")]
        public float speed = 10;//子弹移动速度
        [Tooltip("相邻子弹间的角度")]
        public float angle = 0;//相邻子弹间的角度
        [Tooltip("相邻子弹间的距离")]
        public float distance = 0;//相邻子弹间的距离
        [Tooltip("离发射点的距离")]
        public float centerDis = 0;//离发射点的距离
        [Tooltip("自转角速度")]
        public float selfRotate = 0;//自转角速度
        [HideInInspector]
        public float tempShootTime;//上一次发射时间
        public Quaternion tempRotation;
        public void ResetTempData(Transform center)
        {
            tempShootTime = 0;
            tempRotation = center.rotation;
        }
    }
}

