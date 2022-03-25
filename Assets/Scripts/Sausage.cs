//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.3.0
//     from Assets/Input/Sausage.inputactions
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

public partial class @Sausage : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @Sausage()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Sausage"",
    ""maps"": [
        {
            ""name"": ""UI"",
            ""id"": ""fadf61a6-0acb-49d7-bcc7-9bf1b247e4ad"",
            ""actions"": [
                {
                    ""name"": ""New action"",
                    ""type"": ""Button"",
                    ""id"": ""95f978e1-0c1f-490a-a7a2-4e6a302bfcf2"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""97b837b8-5392-45c2-a0c9-4c59af6bed58"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""New action"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Player"",
            ""id"": ""aa61a2c3-a0f5-4e29-ada1-44a2c0931070"",
            ""actions"": [
                {
                    ""name"": ""MoveA"",
                    ""type"": ""PassThrough"",
                    ""id"": ""788b0b43-fbd6-41e5-b3a6-363678398616"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""MoveB"",
                    ""type"": ""PassThrough"",
                    ""id"": ""68cf9e46-fdd6-4df8-a856-20b55f4f42e0"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""GrabA"",
                    ""type"": ""Button"",
                    ""id"": ""0f48c359-c0f9-4d26-adfc-617b02cbe522"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""GrabB"",
                    ""type"": ""Button"",
                    ""id"": ""b2030f64-bf68-4ac0-8a0f-5c106644dc1c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""3a0241ca-5684-4fe9-9246-025752609b91"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""8e5df4f2-fbd1-429f-a473-f9bc34948c2a"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveA"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""694e8654-42a1-49f6-82c3-9a9df3e5c712"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveA"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""d6052b60-f9a4-49e2-92f1-143d4c17d150"",
                    ""path"": ""<Gamepad>/leftStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveA"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""8dfb069b-898e-46a2-9d36-338831f7d0e7"",
                    ""path"": ""<Gamepad>/leftStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveA"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""344de75d-a702-4f51-b7b0-c284e1911fae"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveA"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""4919e95f-af81-448d-9a56-fee9b1704871"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveA"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""7bc7f039-0ea5-4eaf-aca5-6675ed2cbd6a"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveB"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""ac057690-c234-4fe2-8458-bca7cd07e72d"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveB"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""e3884b32-6dde-44ba-821a-d72999ac13f6"",
                    ""path"": ""<Gamepad>/rightStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveB"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""3ba134cc-9196-458c-9dfd-c11fe882380d"",
                    ""path"": ""<Gamepad>/rightStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveB"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""7ca7fcfc-31cd-4c6c-8fbe-cf1198b6eec8"",
                    ""path"": ""<Gamepad>/rightStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveB"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""23dd3fcc-7083-4771-8340-5038e59e23d5"",
                    ""path"": ""<Gamepad>/rightStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveB"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""e93a1143-b537-4738-88ca-24cde45ec5f5"",
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""GrabA"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""107d961c-0340-45d1-a4dd-8347b2a36f39"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""GrabB"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""23cc2178-6859-4af7-895e-447a0e7756dc"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // UI
        m_UI = asset.FindActionMap("UI", throwIfNotFound: true);
        m_UI_Newaction = m_UI.FindAction("New action", throwIfNotFound: true);
        // Player
        m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
        m_Player_MoveA = m_Player.FindAction("MoveA", throwIfNotFound: true);
        m_Player_MoveB = m_Player.FindAction("MoveB", throwIfNotFound: true);
        m_Player_GrabA = m_Player.FindAction("GrabA", throwIfNotFound: true);
        m_Player_GrabB = m_Player.FindAction("GrabB", throwIfNotFound: true);
        m_Player_Jump = m_Player.FindAction("Jump", throwIfNotFound: true);
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

    // UI
    private readonly InputActionMap m_UI;
    private IUIActions m_UIActionsCallbackInterface;
    private readonly InputAction m_UI_Newaction;
    public struct UIActions
    {
        private @Sausage m_Wrapper;
        public UIActions(@Sausage wrapper) { m_Wrapper = wrapper; }
        public InputAction @Newaction => m_Wrapper.m_UI_Newaction;
        public InputActionMap Get() { return m_Wrapper.m_UI; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(UIActions set) { return set.Get(); }
        public void SetCallbacks(IUIActions instance)
        {
            if (m_Wrapper.m_UIActionsCallbackInterface != null)
            {
                @Newaction.started -= m_Wrapper.m_UIActionsCallbackInterface.OnNewaction;
                @Newaction.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnNewaction;
                @Newaction.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnNewaction;
            }
            m_Wrapper.m_UIActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Newaction.started += instance.OnNewaction;
                @Newaction.performed += instance.OnNewaction;
                @Newaction.canceled += instance.OnNewaction;
            }
        }
    }
    public UIActions @UI => new UIActions(this);

    // Player
    private readonly InputActionMap m_Player;
    private IPlayerActions m_PlayerActionsCallbackInterface;
    private readonly InputAction m_Player_MoveA;
    private readonly InputAction m_Player_MoveB;
    private readonly InputAction m_Player_GrabA;
    private readonly InputAction m_Player_GrabB;
    private readonly InputAction m_Player_Jump;
    public struct PlayerActions
    {
        private @Sausage m_Wrapper;
        public PlayerActions(@Sausage wrapper) { m_Wrapper = wrapper; }
        public InputAction @MoveA => m_Wrapper.m_Player_MoveA;
        public InputAction @MoveB => m_Wrapper.m_Player_MoveB;
        public InputAction @GrabA => m_Wrapper.m_Player_GrabA;
        public InputAction @GrabB => m_Wrapper.m_Player_GrabB;
        public InputAction @Jump => m_Wrapper.m_Player_Jump;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterface != null)
            {
                @MoveA.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMoveA;
                @MoveA.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMoveA;
                @MoveA.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMoveA;
                @MoveB.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMoveB;
                @MoveB.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMoveB;
                @MoveB.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMoveB;
                @GrabA.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnGrabA;
                @GrabA.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnGrabA;
                @GrabA.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnGrabA;
                @GrabB.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnGrabB;
                @GrabB.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnGrabB;
                @GrabB.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnGrabB;
                @Jump.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJump;
            }
            m_Wrapper.m_PlayerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @MoveA.started += instance.OnMoveA;
                @MoveA.performed += instance.OnMoveA;
                @MoveA.canceled += instance.OnMoveA;
                @MoveB.started += instance.OnMoveB;
                @MoveB.performed += instance.OnMoveB;
                @MoveB.canceled += instance.OnMoveB;
                @GrabA.started += instance.OnGrabA;
                @GrabA.performed += instance.OnGrabA;
                @GrabA.canceled += instance.OnGrabA;
                @GrabB.started += instance.OnGrabB;
                @GrabB.performed += instance.OnGrabB;
                @GrabB.canceled += instance.OnGrabB;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
            }
        }
    }
    public PlayerActions @Player => new PlayerActions(this);
    public interface IUIActions
    {
        void OnNewaction(InputAction.CallbackContext context);
    }
    public interface IPlayerActions
    {
        void OnMoveA(InputAction.CallbackContext context);
        void OnMoveB(InputAction.CallbackContext context);
        void OnGrabA(InputAction.CallbackContext context);
        void OnGrabB(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
    }
}
