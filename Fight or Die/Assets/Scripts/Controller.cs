//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.4.4
//     from Assets/Scripts/Controller.inputactions
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

public partial class @Controller : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @Controller()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Controller"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""f54c4626-2f8d-4f1e-ba8e-1a5525d4cff1"",
            ""actions"": [
                {
                    ""name"": ""UpperCut"",
                    ""type"": ""Button"",
                    ""id"": ""70bd0260-9444-4521-bd87-db05f2c5322c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""LowerCut"",
                    ""type"": ""Button"",
                    ""id"": ""34e121ba-8ec1-46d3-99e4-ef14c2ea3f26"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""MediumCut"",
                    ""type"": ""Button"",
                    ""id"": ""ea395f98-9cc7-4023-9b27-a90bdf06646a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Movement"",
                    ""type"": ""PassThrough"",
                    ""id"": ""3ed10551-8995-4de5-8c41-3067d03653ea"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""e9d1fea3-c66d-4b28-9e4a-3d3ed8391564"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Block"",
                    ""type"": ""Button"",
                    ""id"": ""960c5af3-5584-468d-a3ab-b71f5ea64114"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""23113c02-66cd-48b9-a406-158d7799cf7d"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""UpperCut"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e94fe887-5db2-4dfc-a36f-ba8bad6b49f4"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LowerCut"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7fd60c6b-9da9-4a8c-baeb-2a917c0e0e52"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MediumCut"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""52bb8491-9326-4279-9402-ecba9a3289a6"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Left"",
                    ""id"": ""96e16cbf-aa95-404b-bd0b-65e63ca4e4a0"",
                    ""path"": ""<Gamepad>/dpad/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Right"",
                    ""id"": ""cc7778f2-a8b9-4be6-9be4-12ae2b64f887"",
                    ""path"": ""<Gamepad>/dpad/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""de3c3b1a-f24c-45f5-b14f-3dd84c6d968c"",
                    ""path"": ""<Gamepad>/dpad/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""45d56b01-a8b2-413a-bb50-202c0b935470"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": ""Hold(duration=0.01,pressPoint=0.1)"",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Block"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Controller"",
            ""bindingGroup"": ""Controller"",
            ""devices"": [
                {
                    ""devicePath"": ""<Gamepad>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // Player
        m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
        m_Player_UpperCut = m_Player.FindAction("UpperCut", throwIfNotFound: true);
        m_Player_LowerCut = m_Player.FindAction("LowerCut", throwIfNotFound: true);
        m_Player_MediumCut = m_Player.FindAction("MediumCut", throwIfNotFound: true);
        m_Player_Movement = m_Player.FindAction("Movement", throwIfNotFound: true);
        m_Player_Jump = m_Player.FindAction("Jump", throwIfNotFound: true);
        m_Player_Block = m_Player.FindAction("Block", throwIfNotFound: true);
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

    // Player
    private readonly InputActionMap m_Player;
    private IPlayerActions m_PlayerActionsCallbackInterface;
    private readonly InputAction m_Player_UpperCut;
    private readonly InputAction m_Player_LowerCut;
    private readonly InputAction m_Player_MediumCut;
    private readonly InputAction m_Player_Movement;
    private readonly InputAction m_Player_Jump;
    private readonly InputAction m_Player_Block;
    public struct PlayerActions
    {
        private @Controller m_Wrapper;
        public PlayerActions(@Controller wrapper) { m_Wrapper = wrapper; }
        public InputAction @UpperCut => m_Wrapper.m_Player_UpperCut;
        public InputAction @LowerCut => m_Wrapper.m_Player_LowerCut;
        public InputAction @MediumCut => m_Wrapper.m_Player_MediumCut;
        public InputAction @Movement => m_Wrapper.m_Player_Movement;
        public InputAction @Jump => m_Wrapper.m_Player_Jump;
        public InputAction @Block => m_Wrapper.m_Player_Block;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterface != null)
            {
                @UpperCut.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnUpperCut;
                @UpperCut.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnUpperCut;
                @UpperCut.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnUpperCut;
                @LowerCut.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnLowerCut;
                @LowerCut.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnLowerCut;
                @LowerCut.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnLowerCut;
                @MediumCut.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMediumCut;
                @MediumCut.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMediumCut;
                @MediumCut.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMediumCut;
                @Movement.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMovement;
                @Jump.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJump;
                @Block.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnBlock;
                @Block.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnBlock;
                @Block.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnBlock;
            }
            m_Wrapper.m_PlayerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @UpperCut.started += instance.OnUpperCut;
                @UpperCut.performed += instance.OnUpperCut;
                @UpperCut.canceled += instance.OnUpperCut;
                @LowerCut.started += instance.OnLowerCut;
                @LowerCut.performed += instance.OnLowerCut;
                @LowerCut.canceled += instance.OnLowerCut;
                @MediumCut.started += instance.OnMediumCut;
                @MediumCut.performed += instance.OnMediumCut;
                @MediumCut.canceled += instance.OnMediumCut;
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Block.started += instance.OnBlock;
                @Block.performed += instance.OnBlock;
                @Block.canceled += instance.OnBlock;
            }
        }
    }
    public PlayerActions @Player => new PlayerActions(this);
    private int m_ControllerSchemeIndex = -1;
    public InputControlScheme ControllerScheme
    {
        get
        {
            if (m_ControllerSchemeIndex == -1) m_ControllerSchemeIndex = asset.FindControlSchemeIndex("Controller");
            return asset.controlSchemes[m_ControllerSchemeIndex];
        }
    }
    public interface IPlayerActions
    {
        void OnUpperCut(InputAction.CallbackContext context);
        void OnLowerCut(InputAction.CallbackContext context);
        void OnMediumCut(InputAction.CallbackContext context);
        void OnMovement(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnBlock(InputAction.CallbackContext context);
    }
}
