using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace sneak
{
    ///<summary>
    ///
    ///<summary>
    public class Fiction : MonoBehaviour
    {
        private float forceMagnitude;
        private Rigidbody2D rb;
        private void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            forceMagnitude = 0.5f;
        }
        private void Update()
        {
            Vector2 force = - rb.velocity* forceMagnitude;
            rb.AddForce(force);
        }
    }
}

