// GENERATED AUTOMATICALLY FROM 'Assets/scripts/Pong/Player2/Player2_Controls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @Player2_Controls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @Player2_Controls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Player2_Controls"",
    ""maps"": [
        {
            ""name"": ""movementMap"",
            ""id"": ""039c5093-a3f4-4da5-8bfc-dcda0db87085"",
            ""actions"": [
                {
                    ""name"": ""movementAction"",
                    ""type"": ""Button"",
                    ""id"": ""024a8597-86d0-442c-9278-7d7f5f0cadc6"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""5ac0ebcd-c1af-431e-975b-3bcc3e28c77c"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""movementAction"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""758ec895-a0a0-4648-9b04-c346ae1e2c1f"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""movementAction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""48495caa-e5cf-43be-9302-0e050f3cc9ce"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""movementAction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // movementMap
        m_movementMap = asset.FindActionMap("movementMap", throwIfNotFound: true);
        m_movementMap_movementAction = m_movementMap.FindAction("movementAction", throwIfNotFound: true);
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

    // movementMap
    private readonly InputActionMap m_movementMap;
    private IMovementMapActions m_MovementMapActionsCallbackInterface;
    private readonly InputAction m_movementMap_movementAction;
    public struct MovementMapActions
    {
        private @Player2_Controls m_Wrapper;
        public MovementMapActions(@Player2_Controls wrapper) { m_Wrapper = wrapper; }
        public InputAction @movementAction => m_Wrapper.m_movementMap_movementAction;
        public InputActionMap Get() { return m_Wrapper.m_movementMap; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MovementMapActions set) { return set.Get(); }
        public void SetCallbacks(IMovementMapActions instance)
        {
            if (m_Wrapper.m_MovementMapActionsCallbackInterface != null)
            {
                @movementAction.started -= m_Wrapper.m_MovementMapActionsCallbackInterface.OnMovementAction;
                @movementAction.performed -= m_Wrapper.m_MovementMapActionsCallbackInterface.OnMovementAction;
                @movementAction.canceled -= m_Wrapper.m_MovementMapActionsCallbackInterface.OnMovementAction;
            }
            m_Wrapper.m_MovementMapActionsCallbackInterface = instance;
            if (instance != null)
            {
                @movementAction.started += instance.OnMovementAction;
                @movementAction.performed += instance.OnMovementAction;
                @movementAction.canceled += instance.OnMovementAction;
            }
        }
    }
    public MovementMapActions @movementMap => new MovementMapActions(this);
    public interface IMovementMapActions
    {
        void OnMovementAction(InputAction.CallbackContext context);
    }
}
