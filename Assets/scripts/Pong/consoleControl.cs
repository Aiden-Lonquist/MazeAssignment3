// GENERATED AUTOMATICALLY FROM 'Assets/scripts/Pong/consoleControl.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @ConsoleControl : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @ConsoleControl()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""consoleControl"",
    ""maps"": [
        {
            ""name"": ""consoleMap"",
            ""id"": ""77cf8e20-b3a0-4381-a198-ca378e35a8ae"",
            ""actions"": [
                {
                    ""name"": ""Enter"",
                    ""type"": ""Button"",
                    ""id"": ""b29ab585-8552-44ea-95cc-ad134c395fd4"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Tab"",
                    ""type"": ""Button"",
                    ""id"": ""20fa151c-cf55-4099-8757-57234ae97e54"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""2dc44323-d975-4b63-b773-f0f222914762"",
                    ""path"": ""<Keyboard>/enter"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Enter"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e17d8085-f4d7-4e88-a925-9776f01119e4"",
                    ""path"": ""<Keyboard>/tab"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Tab"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // consoleMap
        m_consoleMap = asset.FindActionMap("consoleMap", throwIfNotFound: true);
        m_consoleMap_Enter = m_consoleMap.FindAction("Enter", throwIfNotFound: true);
        m_consoleMap_Tab = m_consoleMap.FindAction("Tab", throwIfNotFound: true);
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

    // consoleMap
    private readonly InputActionMap m_consoleMap;
    private IConsoleMapActions m_ConsoleMapActionsCallbackInterface;
    private readonly InputAction m_consoleMap_Enter;
    private readonly InputAction m_consoleMap_Tab;
    public struct ConsoleMapActions
    {
        private @ConsoleControl m_Wrapper;
        public ConsoleMapActions(@ConsoleControl wrapper) { m_Wrapper = wrapper; }
        public InputAction @Enter => m_Wrapper.m_consoleMap_Enter;
        public InputAction @Tab => m_Wrapper.m_consoleMap_Tab;
        public InputActionMap Get() { return m_Wrapper.m_consoleMap; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(ConsoleMapActions set) { return set.Get(); }
        public void SetCallbacks(IConsoleMapActions instance)
        {
            if (m_Wrapper.m_ConsoleMapActionsCallbackInterface != null)
            {
                @Enter.started -= m_Wrapper.m_ConsoleMapActionsCallbackInterface.OnEnter;
                @Enter.performed -= m_Wrapper.m_ConsoleMapActionsCallbackInterface.OnEnter;
                @Enter.canceled -= m_Wrapper.m_ConsoleMapActionsCallbackInterface.OnEnter;
                @Tab.started -= m_Wrapper.m_ConsoleMapActionsCallbackInterface.OnTab;
                @Tab.performed -= m_Wrapper.m_ConsoleMapActionsCallbackInterface.OnTab;
                @Tab.canceled -= m_Wrapper.m_ConsoleMapActionsCallbackInterface.OnTab;
            }
            m_Wrapper.m_ConsoleMapActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Enter.started += instance.OnEnter;
                @Enter.performed += instance.OnEnter;
                @Enter.canceled += instance.OnEnter;
                @Tab.started += instance.OnTab;
                @Tab.performed += instance.OnTab;
                @Tab.canceled += instance.OnTab;
            }
        }
    }
    public ConsoleMapActions @consoleMap => new ConsoleMapActions(this);
    public interface IConsoleMapActions
    {
        void OnEnter(InputAction.CallbackContext context);
        void OnTab(InputAction.CallbackContext context);
    }
}
