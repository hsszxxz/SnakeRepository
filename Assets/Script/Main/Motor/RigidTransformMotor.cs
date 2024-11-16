using sneak;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace move
{
    ///<summary>
    ///可用输入设备控制的刚体物体的移动方法
    ///<summary>
public class RigidTransformMotor
    {
        public RigidTransformMotor(Transform Target)
        {
            body = Target.GetComponent<Rigidbody2D>();
        }
        private Rigidbody2D body;
        public void MoveToBackward(float moveForce)
        {
            body.AddForce(new Vector2(0,-1) * moveForce, ForceMode2D.Force);
        }
        public void MoveToAllDirection( Vector2 dir,float moveForce)
        {
            body.AddForce(dir * moveForce, ForceMode2D.Force);
        }
        public void MoveToForward(float moveForce)
        {
            body.AddForce(new Vector2(0, 1) * moveForce, ForceMode2D.Force);
        }

        public void MoveToLeft(float moveForce)
        {
            body.AddForce(new Vector2(-1, 0) * moveForce, ForceMode2D.Force);
        }

        public void MoveToRight(float moveForce)
        {
            body.AddForce(new Vector2(1, 0) * moveForce, ForceMode2D.Force);
        }
    }
}

