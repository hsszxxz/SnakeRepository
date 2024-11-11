using sneak;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace move
{
    ///<summary>
    ///���������豸���Ƶĸ���������ƶ�����
    ///<summary>
public class RigidTransformMotor : IControlMovable
    {
        public RigidTransformMotor(Transform Target, float MoveForce)
        {
            body = Target.GetComponent<Rigidbody2D>();
            moveForce = MoveForce;
        }
        private Rigidbody2D body;
        private float moveForce;
        public void MoveToBackward()
        {
            body.AddForce(new Vector2(0,-1) * moveForce, ForceMode2D.Force);
        }

        public void MoveToForward()
        {
            body.AddForce(new Vector2(0, 1) * moveForce, ForceMode2D.Force);
        }

        public void MoveToLeft()
        {
            body.AddForce(new Vector2(-1, 0) * moveForce, ForceMode2D.Force);
        }

        public void MoveToRight()
        {
            body.AddForce(new Vector2(1, 0) * moveForce, ForceMode2D.Force);
        }
    }
}

