//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.7.0
//     from Assets/Script/Main/CharacterInputControl/Character'Input.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @CharacterInput: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @CharacterInput()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Character'Input"",
    ""maps"": [
        {
            ""name"": ""gameplay"",
            ""id"": ""ee688910-8d76-4850-910d-d70517362e79"",
            ""actions"": [
                {
                    ""name"": ""WASDMove"",
                    ""type"": ""Value"",
                    ""id"": ""226b1f56-afe4-42f6-96aa-e85bcca3c04c"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""ArrowMove"",
                    ""type"": ""Value"",
                    ""id"": ""c6558d51-902f-4b88-ba12-ec89f0f9fadd"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Skill"",
                    ""type"": ""Button"",
                    ""id"": ""f6b2350a-bbca-4cdd-be0a-37f4ba09155e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Confirm"",
                    ""type"": ""Button"",
                    ""id"": ""b877a7ff-6326-4099-ac9e-670f73a3e885"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Cancel"",
                    ""type"": ""Button"",
                    ""id"": ""08b88fa7-52fc-4d73-9433-11be3c1049b0"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WASD"",
                    ""id"": ""777eee7a-0e46-4b61-9ebd-71af2871c407"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""WASDMove"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""500b6b92-80f1-40da-892f-02b63dd8d666"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyBoard"",
                    ""action"": ""WASDMove"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""f1afa4bf-1902-47cb-bea7-2125f8f28543"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyBoard"",
                    ""action"": ""WASDMove"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""ec559991-368f-42c5-b1f2-589e3b116651"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyBoard"",
                    ""action"": ""WASDMove"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""7bff4da1-fba2-4971-8d27-451936a01b09"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyBoard"",
                    ""action"": ""WASDMove"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Arrow"",
                    ""id"": ""a70541a5-749a-4b54-983e-59a1c423ff6e"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ArrowMove"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""d42ec011-5143-4217-9c1c-e0f30a3731d6"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyBoard"",
                    ""action"": ""ArrowMove"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""ca900c36-b86e-4a80-941b-fbaf2182954e"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyBoard"",
                    ""action"": ""ArrowMove"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""bcbee509-5e2d-4a24-875e-6d01e88a4b97"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyBoard"",
                    ""action"": ""ArrowMove"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""47433558-bfcf-480f-ace5-cf072b2dbdf9"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyBoard"",
                    ""action"": ""ArrowMove"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""edafc7c6-bd72-4a96-b4d8-c7e02055a51f"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyBoard"",
                    ""action"": ""Skill"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a268ae3f-cc8a-4ce9-b55f-b39cf94a6c16"",
                    ""path"": ""<Keyboard>/enter"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyBoard"",
                    ""action"": ""Confirm"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9f5bc9c2-f971-49a3-bb7c-8197180cfe24"",
                    ""path"": ""<Keyboard>/delete"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyBoard"",
                    ""action"": ""Cancel"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""handleplay"",
            ""id"": ""aa78b6dd-ccbc-46ee-8eb1-0f8e361db069"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""2cbe4bdf-ea75-4be6-88b6-6a5b49378128"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""BulletAttack"",
                    ""type"": ""Value"",
                    ""id"": ""174c0b4c-7dbf-43b8-aab7-3e2d3013f264"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""SkillButton"",
                    ""type"": ""Button"",
                    ""id"": ""8606fee4-0c8e-4939-a116-b9d4b4e752b1"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""BulletConfirm"",
                    ""type"": ""Button"",
                    ""id"": ""26f0da83-ff6d-4a21-b197-95bcc8ca84b1"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Confirm"",
                    ""type"": ""Button"",
                    ""id"": ""23679dc3-ff42-4433-9d20-a6c55a8ab843"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Cancel"",
                    ""type"": ""Button"",
                    ""id"": ""97b02d2e-1c99-4086-88af-d79c56385393"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""LeftMove"",
                    ""id"": ""8693209c-a368-4ec9-a5c0-724aaa286c0e"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""697022ac-8481-4d21-b74c-d201deeb7e61"",
                    ""path"": ""<Gamepad>/leftStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""c3e00d76-f396-4942-92bf-b1e6f8c42957"",
                    ""path"": ""<Gamepad>/leftStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""9c3f3af4-73d1-4143-a320-b950256304a3"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""80059631-b2e0-46c7-8139-d3f1b5db4764"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""ShiZiMove"",
                    ""id"": ""d7a3dd75-11eb-4248-8a59-3fdb7f113378"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""cc4d82b9-fd03-4f98-bf7e-86f42896e000"",
                    ""path"": ""<Gamepad>/dpad/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""28c9a924-61ff-4449-b787-a6b4fac11c3c"",
                    ""path"": ""<Gamepad>/dpad/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""5c83205a-3928-4bd2-a061-f72c45134a88"",
                    ""path"": ""<Gamepad>/dpad/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""90534849-2dff-48ed-b952-6cc45e4bd247"",
                    ""path"": ""<Gamepad>/dpad/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""BulletDir"",
                    ""id"": ""e22f723c-150f-41f7-b63b-dad7c3e09082"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""BulletAttack"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""eea0c82a-a86b-4da5-87de-a46218d8be3b"",
                    ""path"": ""<Gamepad>/rightStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""BulletAttack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""6752505f-f4e8-4ced-8f92-e40a0da98137"",
                    ""path"": ""<Gamepad>/rightStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""BulletAttack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""375037b7-40e9-46f8-ae71-a0fb41763848"",
                    ""path"": ""<Gamepad>/rightStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""BulletAttack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""f41393a6-6a17-4772-87d6-a941b00415f0"",
                    ""path"": ""<Gamepad>/rightStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""BulletAttack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""749dd5e3-1a84-4add-9b9c-03577d3a3d9c"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SkillButton"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f00e5166-cdf2-41f3-80a0-b4a1365c7a32"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""BulletConfirm"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""fe80f824-0f3a-4f70-8d38-856fb22530f5"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Confirm"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4883041a-47b4-416b-a809-92026b0540e9"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Cancel"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""KeyBoard"",
            ""bindingGroup"": ""KeyBoard"",
            ""devices"": []
        }
    ]
}");
        // gameplay
        m_gameplay = asset.FindActionMap("gameplay", throwIfNotFound: true);
        m_gameplay_WASDMove = m_gameplay.FindAction("WASDMove", throwIfNotFound: true);
        m_gameplay_ArrowMove = m_gameplay.FindAction("ArrowMove", throwIfNotFound: true);
        m_gameplay_Skill = m_gameplay.FindAction("Skill", throwIfNotFound: true);
        m_gameplay_Confirm = m_gameplay.FindAction("Confirm", throwIfNotFound: true);
        m_gameplay_Cancel = m_gameplay.FindAction("Cancel", throwIfNotFound: true);
        // handleplay
        m_handleplay = asset.FindActionMap("handleplay", throwIfNotFound: true);
        m_handleplay_Move = m_handleplay.FindAction("Move", throwIfNotFound: true);
        m_handleplay_BulletAttack = m_handleplay.FindAction("BulletAttack", throwIfNotFound: true);
        m_handleplay_SkillButton = m_handleplay.FindAction("SkillButton", throwIfNotFound: true);
        m_handleplay_BulletConfirm = m_handleplay.FindAction("BulletConfirm", throwIfNotFound: true);
        m_handleplay_Confirm = m_handleplay.FindAction("Confirm", throwIfNotFound: true);
        m_handleplay_Cancel = m_handleplay.FindAction("Cancel", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }

    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // gameplay
    private readonly InputActionMap m_gameplay;
    private List<IGameplayActions> m_GameplayActionsCallbackInterfaces = new List<IGameplayActions>();
    private readonly InputAction m_gameplay_WASDMove;
    private readonly InputAction m_gameplay_ArrowMove;
    private readonly InputAction m_gameplay_Skill;
    private readonly InputAction m_gameplay_Confirm;
    private readonly InputAction m_gameplay_Cancel;
    public struct GameplayActions
    {
        private @CharacterInput m_Wrapper;
        public GameplayActions(@CharacterInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @WASDMove => m_Wrapper.m_gameplay_WASDMove;
        public InputAction @ArrowMove => m_Wrapper.m_gameplay_ArrowMove;
        public InputAction @Skill => m_Wrapper.m_gameplay_Skill;
        public InputAction @Confirm => m_Wrapper.m_gameplay_Confirm;
        public InputAction @Cancel => m_Wrapper.m_gameplay_Cancel;
        public InputActionMap Get() { return m_Wrapper.m_gameplay; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GameplayActions set) { return set.Get(); }
        public void AddCallbacks(IGameplayActions instance)
        {
            if (instance == null || m_Wrapper.m_GameplayActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_GameplayActionsCallbackInterfaces.Add(instance);
            @WASDMove.started += instance.OnWASDMove;
            @WASDMove.performed += instance.OnWASDMove;
            @WASDMove.canceled += instance.OnWASDMove;
            @ArrowMove.started += instance.OnArrowMove;
            @ArrowMove.performed += instance.OnArrowMove;
            @ArrowMove.canceled += instance.OnArrowMove;
            @Skill.started += instance.OnSkill;
            @Skill.performed += instance.OnSkill;
            @Skill.canceled += instance.OnSkill;
            @Confirm.started += instance.OnConfirm;
            @Confirm.performed += instance.OnConfirm;
            @Confirm.canceled += instance.OnConfirm;
            @Cancel.started += instance.OnCancel;
            @Cancel.performed += instance.OnCancel;
            @Cancel.canceled += instance.OnCancel;
        }

        private void UnregisterCallbacks(IGameplayActions instance)
        {
            @WASDMove.started -= instance.OnWASDMove;
            @WASDMove.performed -= instance.OnWASDMove;
            @WASDMove.canceled -= instance.OnWASDMove;
            @ArrowMove.started -= instance.OnArrowMove;
            @ArrowMove.performed -= instance.OnArrowMove;
            @ArrowMove.canceled -= instance.OnArrowMove;
            @Skill.started -= instance.OnSkill;
            @Skill.performed -= instance.OnSkill;
            @Skill.canceled -= instance.OnSkill;
            @Confirm.started -= instance.OnConfirm;
            @Confirm.performed -= instance.OnConfirm;
            @Confirm.canceled -= instance.OnConfirm;
            @Cancel.started -= instance.OnCancel;
            @Cancel.performed -= instance.OnCancel;
            @Cancel.canceled -= instance.OnCancel;
        }

        public void RemoveCallbacks(IGameplayActions instance)
        {
            if (m_Wrapper.m_GameplayActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IGameplayActions instance)
        {
            foreach (var item in m_Wrapper.m_GameplayActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_GameplayActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public GameplayActions @gameplay => new GameplayActions(this);

    // handleplay
    private readonly InputActionMap m_handleplay;
    private List<IHandleplayActions> m_HandleplayActionsCallbackInterfaces = new List<IHandleplayActions>();
    private readonly InputAction m_handleplay_Move;
    private readonly InputAction m_handleplay_BulletAttack;
    private readonly InputAction m_handleplay_SkillButton;
    private readonly InputAction m_handleplay_BulletConfirm;
    private readonly InputAction m_handleplay_Confirm;
    private readonly InputAction m_handleplay_Cancel;
    public struct HandleplayActions
    {
        private @CharacterInput m_Wrapper;
        public HandleplayActions(@CharacterInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_handleplay_Move;
        public InputAction @BulletAttack => m_Wrapper.m_handleplay_BulletAttack;
        public InputAction @SkillButton => m_Wrapper.m_handleplay_SkillButton;
        public InputAction @BulletConfirm => m_Wrapper.m_handleplay_BulletConfirm;
        public InputAction @Confirm => m_Wrapper.m_handleplay_Confirm;
        public InputAction @Cancel => m_Wrapper.m_handleplay_Cancel;
        public InputActionMap Get() { return m_Wrapper.m_handleplay; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(HandleplayActions set) { return set.Get(); }
        public void AddCallbacks(IHandleplayActions instance)
        {
            if (instance == null || m_Wrapper.m_HandleplayActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_HandleplayActionsCallbackInterfaces.Add(instance);
            @Move.started += instance.OnMove;
            @Move.performed += instance.OnMove;
            @Move.canceled += instance.OnMove;
            @BulletAttack.started += instance.OnBulletAttack;
            @BulletAttack.performed += instance.OnBulletAttack;
            @BulletAttack.canceled += instance.OnBulletAttack;
            @SkillButton.started += instance.OnSkillButton;
            @SkillButton.performed += instance.OnSkillButton;
            @SkillButton.canceled += instance.OnSkillButton;
            @BulletConfirm.started += instance.OnBulletConfirm;
            @BulletConfirm.performed += instance.OnBulletConfirm;
            @BulletConfirm.canceled += instance.OnBulletConfirm;
            @Confirm.started += instance.OnConfirm;
            @Confirm.performed += instance.OnConfirm;
            @Confirm.canceled += instance.OnConfirm;
            @Cancel.started += instance.OnCancel;
            @Cancel.performed += instance.OnCancel;
            @Cancel.canceled += instance.OnCancel;
        }

        private void UnregisterCallbacks(IHandleplayActions instance)
        {
            @Move.started -= instance.OnMove;
            @Move.performed -= instance.OnMove;
            @Move.canceled -= instance.OnMove;
            @BulletAttack.started -= instance.OnBulletAttack;
            @BulletAttack.performed -= instance.OnBulletAttack;
            @BulletAttack.canceled -= instance.OnBulletAttack;
            @SkillButton.started -= instance.OnSkillButton;
            @SkillButton.performed -= instance.OnSkillButton;
            @SkillButton.canceled -= instance.OnSkillButton;
            @BulletConfirm.started -= instance.OnBulletConfirm;
            @BulletConfirm.performed -= instance.OnBulletConfirm;
            @BulletConfirm.canceled -= instance.OnBulletConfirm;
            @Confirm.started -= instance.OnConfirm;
            @Confirm.performed -= instance.OnConfirm;
            @Confirm.canceled -= instance.OnConfirm;
            @Cancel.started -= instance.OnCancel;
            @Cancel.performed -= instance.OnCancel;
            @Cancel.canceled -= instance.OnCancel;
        }

        public void RemoveCallbacks(IHandleplayActions instance)
        {
            if (m_Wrapper.m_HandleplayActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IHandleplayActions instance)
        {
            foreach (var item in m_Wrapper.m_HandleplayActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_HandleplayActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public HandleplayActions @handleplay => new HandleplayActions(this);
    private int m_KeyBoardSchemeIndex = -1;
    public InputControlScheme KeyBoardScheme
    {
        get
        {
            if (m_KeyBoardSchemeIndex == -1) m_KeyBoardSchemeIndex = asset.FindControlSchemeIndex("KeyBoard");
            return asset.controlSchemes[m_KeyBoardSchemeIndex];
        }
    }
    public interface IGameplayActions
    {
        void OnWASDMove(InputAction.CallbackContext context);
        void OnArrowMove(InputAction.CallbackContext context);
        void OnSkill(InputAction.CallbackContext context);
        void OnConfirm(InputAction.CallbackContext context);
        void OnCancel(InputAction.CallbackContext context);
    }
    public interface IHandleplayActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnBulletAttack(InputAction.CallbackContext context);
        void OnSkillButton(InputAction.CallbackContext context);
        void OnBulletConfirm(InputAction.CallbackContext context);
        void OnConfirm(InputAction.CallbackContext context);
        void OnCancel(InputAction.CallbackContext context);
    }
}
