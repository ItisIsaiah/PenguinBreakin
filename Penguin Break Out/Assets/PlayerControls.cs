//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.3.0
//     from Assets/PlayerControls.inputactions
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

public partial class @PlayerControls : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerControls"",
    ""maps"": [
        {
            ""name"": ""Controller"",
            ""id"": ""e7fe0fa2-a353-4fe6-bfb3-c0167250f2cd"",
            ""actions"": [
                {
                    ""name"": ""Walk"",
                    ""type"": ""Value"",
                    ""id"": ""55ebc30b-1733-4c91-b6ae-9a585dc455bd"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Look"",
                    ""type"": ""Value"",
                    ""id"": ""e5dae769-7b23-435c-add9-8dd7cefbd154"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Swing"",
                    ""type"": ""Button"",
                    ""id"": ""b8f4b032-6240-4b15-ae21-98f8147285ca"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""b324850e-d353-45d1-8df5-4a7d412a100d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""a29a00d2-3ae8-4ec6-b088-9c31d39d44ef"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Walk"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""011b8f7d-94ab-4e01-ab07-1c2745474ec9"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Walk"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""d2dadc62-4bc5-4ab5-892c-86cf8705ef05"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Walk"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""34afb87b-fdbb-4c8a-99be-239b397bfb49"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Walk"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""1668462c-8f94-43a6-a204-45c6df0e0a69"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Walk"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""98022916-f0d1-4a87-badf-96d986cffb27"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Walk"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""5a528209-ba11-4ce6-bc97-fa1e06b6513b"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Look"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b86f61f2-4ed9-4c39-95cc-3c99bed869fd"",
                    ""path"": ""<Pointer>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Look"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""293bb1fc-1a9d-4dfd-9a4d-683abfbb4b1f"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Swing"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a51077ad-9064-47ad-aaf3-139636bc3d0c"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Swing"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""27295af2-5b13-48f1-8016-c0282a6c5623"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""787f7f5c-b2df-444b-83ba-8625169834f1"",
                    ""path"": ""<Keyboard>/space"",
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
        // Controller
        m_Controller = asset.FindActionMap("Controller", throwIfNotFound: true);
        m_Controller_Walk = m_Controller.FindAction("Walk", throwIfNotFound: true);
        m_Controller_Look = m_Controller.FindAction("Look", throwIfNotFound: true);
        m_Controller_Swing = m_Controller.FindAction("Swing", throwIfNotFound: true);
        m_Controller_Jump = m_Controller.FindAction("Jump", throwIfNotFound: true);
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

    // Controller
    private readonly InputActionMap m_Controller;
    private IControllerActions m_ControllerActionsCallbackInterface;
    private readonly InputAction m_Controller_Walk;
    private readonly InputAction m_Controller_Look;
    private readonly InputAction m_Controller_Swing;
    private readonly InputAction m_Controller_Jump;
    public struct ControllerActions
    {
        private @PlayerControls m_Wrapper;
        public ControllerActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Walk => m_Wrapper.m_Controller_Walk;
        public InputAction @Look => m_Wrapper.m_Controller_Look;
        public InputAction @Swing => m_Wrapper.m_Controller_Swing;
        public InputAction @Jump => m_Wrapper.m_Controller_Jump;
        public InputActionMap Get() { return m_Wrapper.m_Controller; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(ControllerActions set) { return set.Get(); }
        public void SetCallbacks(IControllerActions instance)
        {
            if (m_Wrapper.m_ControllerActionsCallbackInterface != null)
            {
                @Walk.started -= m_Wrapper.m_ControllerActionsCallbackInterface.OnWalk;
                @Walk.performed -= m_Wrapper.m_ControllerActionsCallbackInterface.OnWalk;
                @Walk.canceled -= m_Wrapper.m_ControllerActionsCallbackInterface.OnWalk;
                @Look.started -= m_Wrapper.m_ControllerActionsCallbackInterface.OnLook;
                @Look.performed -= m_Wrapper.m_ControllerActionsCallbackInterface.OnLook;
                @Look.canceled -= m_Wrapper.m_ControllerActionsCallbackInterface.OnLook;
                @Swing.started -= m_Wrapper.m_ControllerActionsCallbackInterface.OnSwing;
                @Swing.performed -= m_Wrapper.m_ControllerActionsCallbackInterface.OnSwing;
                @Swing.canceled -= m_Wrapper.m_ControllerActionsCallbackInterface.OnSwing;
                @Jump.started -= m_Wrapper.m_ControllerActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_ControllerActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_ControllerActionsCallbackInterface.OnJump;
            }
            m_Wrapper.m_ControllerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Walk.started += instance.OnWalk;
                @Walk.performed += instance.OnWalk;
                @Walk.canceled += instance.OnWalk;
                @Look.started += instance.OnLook;
                @Look.performed += instance.OnLook;
                @Look.canceled += instance.OnLook;
                @Swing.started += instance.OnSwing;
                @Swing.performed += instance.OnSwing;
                @Swing.canceled += instance.OnSwing;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
            }
        }
    }
    public ControllerActions @Controller => new ControllerActions(this);
    public interface IControllerActions
    {
        void OnWalk(InputAction.CallbackContext context);
        void OnLook(InputAction.CallbackContext context);
        void OnSwing(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
    }
}
