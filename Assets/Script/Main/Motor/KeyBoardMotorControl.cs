using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
namespace move
{
    ///<summary>
    ///用键盘控制移动
    ///<summary>

    //使用哪一套键盘键位
    public enum KeyBoardKit
    {
        WASD,
        Arrow
    }
    public class KeyBoardMotorControl
    {
        public KeyBoardMotorControl(KeyBoardKit kit, Transform self,float moveForce)
        {
            switch (kit)
            {
                case KeyBoardKit.WASD:
                    keys = new List<KeyCode>()
                    {
                        KeyCode.W,
                        KeyCode.S,
                        KeyCode.A,
                        KeyCode.D
                    };
                    break;
                case KeyBoardKit.Arrow:
                    keys = new List<KeyCode>()
                    {
                        KeyCode.UpArrow,
                        KeyCode.DownArrow,
                        KeyCode.LeftArrow,
                        KeyCode.RightArrow,
                    };
                    break;
            }
            motor = new RigidTransformMotor(self, moveForce);
        }
        private List<KeyCode> keys;
        private RigidTransformMotor motor;
        public  void MoveControl()
        {
            if (Input.GetKey(keys[0]))
            {
                motor.MoveToForward();
            }
            if (Input.GetKey(keys[1]))
            {
                motor.MoveToBackward();
            }
            if (Input.GetKey(keys[2]))
            {
                motor.MoveToLeft();
            }
            if (Input.GetKey(keys[3]))
            {
                motor.MoveToRight();
            }
        }
    }
}

