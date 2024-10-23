using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
namespace sneak
{

    ///<summary>
    ///
    ///<summary>
    public abstract class SneakBody : MonoBehaviour
    {
        [HideInInspector]
        public Rigidbody2D rigidbody;
        private Collider2D collider;
        private HingeJoint2D hingeJoint;
        private SneakBody previousValue;
        private SpringJoint2D springJoint;
        [HideInInspector]
        public SneakBody previousBody
        {
            get
            {
                return previousValue;
            }
            set
            {
                previousValue = value;
                if (value != null && type != HeadType.Head1)
                { 
                    hingeJoint.connectedBody = value.rigidbody;
                }
                if (value != null && type != HeadType.Head1 && type != HeadType.Head2)
                {
                    springJoint.connectedBody = value.rigidbody;
                }
            }

        }
        [HideInInspector]
        public SneakBody nextBody;
        [HideInInspector]
        public HeadType type;
        protected virtual void Awake()
        {
            rigidbody = GetComponent<Rigidbody2D>();
            collider = GetComponent<Collider2D>();
            hingeJoint = GetComponent<HingeJoint2D>();
            springJoint = GetComponent<SpringJoint2D>();
            Init();
        }
        protected abstract void Init();
    }
}

