using attack;
using move;
using sneak;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
namespace control
{
    ///<summary>
    ///
    ///<summary>
    public enum InputDevice
    {
        KeyBoard,
        Handle
    }
    public class InputControl
    {
        public InputControl(InputDevice Device,Transform Self,HeadType headType)
        {
            device = Device;
            self = Self;
            inputAction = new CharacterInput();
            motor = new RigidTransformMotor(self);
            if (device == InputDevice.KeyBoard)
            {
                if (headType == HeadType.Head1)
                {
                    inputAction.gameplay.WASDMove.performed += Input => moveDir = Input.ReadValue<Vector2>();
                    inputAction.gameplay.WASDMove.canceled += Input => moveDir = Vector2.zero;
                }
                else if (headType == HeadType.Head2)
                {
                   
                    inputAction.gameplay.ArrowMove.performed += Input => moveDir = Input.ReadValue<Vector2>();
                    inputAction.gameplay.ArrowMove.canceled += Input => moveDir = Vector2.zero;
                }
            }
            else if (device == InputDevice.Handle)
            {
                if (headType == HeadType.Head1)
                {
                    inputAction.handleplay.Move.performed += Input => moveDir = Input.ReadValue<Vector2>();
                    inputAction.handleplay.Move.canceled += Input => moveDir = Vector2.zero;
                }
                else if (headType == HeadType.Head2)
                {
                    inputAction.handleplay.Move.performed += Input => moveDir = Input.ReadValue<Vector2>();
                    inputAction.handleplay.Move.canceled += Input => moveDir = Vector2.zero;

                    inputAction.handleplay.BulletAttack.canceled += input => handleAttackDir = input.ReadValue<Vector2>(); 
                }
            }
            inputAction.Enable();
            SneakManager.Instance.inputControlers.Add(inputAction);
        }
        private InputDevice device;
        private CharacterInput inputAction;
        private RigidTransformMotor motor;
        private Vector2 moveDir;
        private Vector2 handleAttackDir;
        private Transform self;
        public bool SkillButtonCancel()
        {
            if (device == InputDevice.KeyBoard)
            {
                return inputAction.gameplay.Skill.WasReleasedThisFrame();
            }
            else if (device == InputDevice.Handle)
            {
                return inputAction.handleplay.SkillButton.WasReleasedThisFrame();
            }
            return false;
        }
        public Vector2 BulletAttackFaceDirection()
        {
            if (device == InputDevice.KeyBoard)
            {
                return Camera.main.ScreenToViewportPoint(Input.mousePosition) - Camera.main.WorldToViewportPoint(self.position);
            }
            else
            {
                return inputAction.handleplay.BulletAttack.ReadValue<Vector2>();
            }
        }
        public bool SkillButtonPress()
        {
            if (device == InputDevice.KeyBoard)
            {
                return inputAction.gameplay.Skill.WasPerformedThisFrame();
            }
            else if (device == InputDevice.Handle)
            {
                return inputAction.handleplay.SkillButton.WasPerformedThisFrame();
            }
            return false;
        }
        public bool BulletAttackButton(BulletAttack bulletAttack)
        {
            if (device == InputDevice.KeyBoard)
            {
                if (Input.GetMouseButtonUp(1))
                {
                    Vector3 target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    bulletAttack.targetPos  = target;
                    bulletAttack.Attack();
                    return true;
                }
            }
            else if (device == InputDevice.Handle)
            {
                if (inputAction.handleplay.BulletConfirm.WasPressedThisFrame())
                {
                    Vector2 s =Camera.main.WorldToViewportPoint(self.position);
                   Vector3 target =Camera.main.ViewportToWorldPoint(s + inputAction.handleplay.BulletAttack.ReadValue<Vector2>());
                    bulletAttack.targetPos = target;
                    bulletAttack.Attack(); 
                    return true;
                }
            }
            return false;
        }
        public void Move(float moveForce)
        {
            motor.MoveToAllDirection(moveDir, moveForce);
        }
    }
}

