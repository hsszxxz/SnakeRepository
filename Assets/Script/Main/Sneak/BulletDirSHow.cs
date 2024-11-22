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
        private float angleValue;
        public float angle
        {
            get { return angleValue; }
            set
            {
                angleValue = value;
                transform.rotation = Quaternion.Euler(0, 0, value);
            }
        }
    }
}

