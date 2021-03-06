// GENERATED AUTOMATICALLY FROM 'Assets/ControllerActions4.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @ControllerActions4 : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @ControllerActions4()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""ControllerActions4"",
    ""maps"": [
        {
            ""name"": ""Gameplay"",
            ""id"": ""f043abd6-c3b9-4632-96c4-06d1f9004d09"",
            ""actions"": [
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""ce260946-564d-4c8e-ace1-1727f9c33723"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Attach"",
                    ""type"": ""Button"",
                    ""id"": ""e93c064f-69cd-4c0e-a6a6-133a17d773ca"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Detach"",
                    ""type"": ""Button"",
                    ""id"": ""48fc5c0c-784d-4097-a294-87aeb94ef195"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""TurretFire"",
                    ""type"": ""Button"",
                    ""id"": ""7c317011-5f0b-46cb-83c4-b9596ded2316"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""Move"",
                    ""type"": ""Button"",
                    ""id"": ""31b03754-2f1f-4dc2-bed0-104ce4156dec"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Continue"",
                    ""type"": ""Button"",
                    ""id"": ""74b51ad8-804a-4178-985b-59188ed663c8"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": ""Hold""
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""a36a40d4-9383-4360-b178-fbab1e518c36"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""910e20c4-7da0-4be8-85bd-2563be626d53"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Attach"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""efb36527-de22-4353-83ff-cba1649a2820"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Detach"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""08f0a578-4568-430a-a8a9-09129e54b715"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TurretFire"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""50b80cf9-d58f-43ea-a0f5-8543a9400130"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""62e4d5a1-89b3-4535-b2e4-0677866c408a"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Continue"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Gameplay
        m_Gameplay = asset.FindActionMap("Gameplay", throwIfNotFound: true);
        m_Gameplay_Jump = m_Gameplay.FindAction("Jump", throwIfNotFound: true);
        m_Gameplay_Attach = m_Gameplay.FindAction("Attach", throwIfNotFound: true);
        m_Gameplay_Detach = m_Gameplay.FindAction("Detach", throwIfNotFound: true);
        m_Gameplay_TurretFire = m_Gameplay.FindAction("TurretFire", throwIfNotFound: true);
        m_Gameplay_Move = m_Gameplay.FindAction("Move", throwIfNotFound: true);
        m_Gameplay_Continue = m_Gameplay.FindAction("Continue", throwIfNotFound: true);
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

    // Gameplay
    private readonly InputActionMap m_Gameplay;
    private IGameplayActions m_GameplayActionsCallbackInterface;
    private readonly InputAction m_Gameplay_Jump;
    private readonly InputAction m_Gameplay_Attach;
    private readonly InputAction m_Gameplay_Detach;
    private readonly InputAction m_Gameplay_TurretFire;
    private readonly InputAction m_Gameplay_Move;
    private readonly InputAction m_Gameplay_Continue;
    public struct GameplayActions
    {
        private @ControllerActions4 m_Wrapper;
        public GameplayActions(@ControllerActions4 wrapper) { m_Wrapper = wrapper; }
        public InputAction @Jump => m_Wrapper.m_Gameplay_Jump;
        public InputAction @Attach => m_Wrapper.m_Gameplay_Attach;
        public InputAction @Detach => m_Wrapper.m_Gameplay_Detach;
        public InputAction @TurretFire => m_Wrapper.m_Gameplay_TurretFire;
        public InputAction @Move => m_Wrapper.m_Gameplay_Move;
        public InputAction @Continue => m_Wrapper.m_Gameplay_Continue;
        public InputActionMap Get() { return m_Wrapper.m_Gameplay; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GameplayActions set) { return set.Get(); }
        public void SetCallbacks(IGameplayActions instance)
        {
            if (m_Wrapper.m_GameplayActionsCallbackInterface != null)
            {
                @Jump.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnJump;
                @Attach.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnAttach;
                @Attach.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnAttach;
                @Attach.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnAttach;
                @Detach.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnDetach;
                @Detach.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnDetach;
                @Detach.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnDetach;
                @TurretFire.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnTurretFire;
                @TurretFire.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnTurretFire;
                @TurretFire.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnTurretFire;
                @Move.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMove;
                @Continue.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnContinue;
                @Continue.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnContinue;
                @Continue.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnContinue;
            }
            m_Wrapper.m_GameplayActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Attach.started += instance.OnAttach;
                @Attach.performed += instance.OnAttach;
                @Attach.canceled += instance.OnAttach;
                @Detach.started += instance.OnDetach;
                @Detach.performed += instance.OnDetach;
                @Detach.canceled += instance.OnDetach;
                @TurretFire.started += instance.OnTurretFire;
                @TurretFire.performed += instance.OnTurretFire;
                @TurretFire.canceled += instance.OnTurretFire;
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Continue.started += instance.OnContinue;
                @Continue.performed += instance.OnContinue;
                @Continue.canceled += instance.OnContinue;
            }
        }
    }
    public GameplayActions @Gameplay => new GameplayActions(this);
    public interface IGameplayActions
    {
        void OnJump(InputAction.CallbackContext context);
        void OnAttach(InputAction.CallbackContext context);
        void OnDetach(InputAction.CallbackContext context);
        void OnTurretFire(InputAction.CallbackContext context);
        void OnMove(InputAction.CallbackContext context);
        void OnContinue(InputAction.CallbackContext context);
    }
}
