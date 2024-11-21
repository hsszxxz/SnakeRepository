using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace sneak
{
    ///<summary>
    ///
    ///<summary>
    public class BulletDirSHow : MonoBehaviour
    {
        private float radius;
        private float angleValue;
        private void Start()
        {
            radius = Vector2.Distance(transform.localPosition,new Vector2(0,0));
        }
        public float angle
        {
            get { return angleValue; }
            set
            {
                angleValue = value;
                float x = Mathf.Cos(value * Mathf.Deg2Rad) * radius;
                float y = Mathf.Sin(value * Mathf.Deg2Rad) * radius;
                transform.localPosition = new Vector2(x, y);
                transform.rotation = Quaternion.Euler(0, 0, value+90);
            }
        }
        
    }
}

