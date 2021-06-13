// GENERATED AUTOMATICALLY FROM 'Assets/GameObjects/Input/BaseControlSet.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @BaseControlSet : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @BaseControlSet()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""BaseControlSet"",
    ""maps"": [
        {
            ""name"": ""BaseMap"",
            ""id"": ""b5900886-2018-46e4-8949-8ea265f492cc"",
            ""actions"": [
                {
                    ""name"": ""Shoot"",
                    ""type"": ""Button"",
                    ""id"": ""35b9a447-0b08-4f33-afa1-315bb4168a47"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MousePos"",
                    ""type"": ""Value"",
                    ""id"": ""cc4b5680-c4ff-402a-927f-d64193ee550f"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""576eea10-ed90-4708-9612-e8863e88b672"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": ""BaseSceme"",
                    ""action"": ""Shoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""BaseSceme"",
            ""bindingGroup"": ""BaseSceme"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // BaseMap
        m_BaseMap = asset.FindActionMap("BaseMap", throwIfNotFound: true);
        m_BaseMap_Shoot = m_BaseMap.FindAction("Shoot", throwIfNotFound: true);
        m_BaseMap_MousePos = m_BaseMap.FindAction("MousePos", throwIfNotFound: true);
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

    // BaseMap
    private readonly InputActionMap m_BaseMap;
    private IBaseMapActions m_BaseMapActionsCallbackInterface;
    private readonly InputAction m_BaseMap_Shoot;
    private readonly InputAction m_BaseMap_MousePos;
    public struct BaseMapActions
    {
        private @BaseControlSet m_Wrapper;
        public BaseMapActions(@BaseControlSet wrapper) { m_Wrapper = wrapper; }
        public InputAction @Shoot => m_Wrapper.m_BaseMap_Shoot;
        public InputAction @MousePos => m_Wrapper.m_BaseMap_MousePos;
        public InputActionMap Get() { return m_Wrapper.m_BaseMap; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(BaseMapActions set) { return set.Get(); }
        public void SetCallbacks(IBaseMapActions instance)
        {
            if (m_Wrapper.m_BaseMapActionsCallbackInterface != null)
            {
                @Shoot.started -= m_Wrapper.m_BaseMapActionsCallbackInterface.OnShoot;
                @Shoot.performed -= m_Wrapper.m_BaseMapActionsCallbackInterface.OnShoot;
                @Shoot.canceled -= m_Wrapper.m_BaseMapActionsCallbackInterface.OnShoot;
                @MousePos.started -= m_Wrapper.m_BaseMapActionsCallbackInterface.OnMousePos;
                @MousePos.performed -= m_Wrapper.m_BaseMapActionsCallbackInterface.OnMousePos;
                @MousePos.canceled -= m_Wrapper.m_BaseMapActionsCallbackInterface.OnMousePos;
            }
            m_Wrapper.m_BaseMapActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Shoot.started += instance.OnShoot;
                @Shoot.performed += instance.OnShoot;
                @Shoot.canceled += instance.OnShoot;
                @MousePos.started += instance.OnMousePos;
                @MousePos.performed += instance.OnMousePos;
                @MousePos.canceled += instance.OnMousePos;
            }
        }
    }
    public BaseMapActions @BaseMap => new BaseMapActions(this);
    private int m_BaseScemeSchemeIndex = -1;
    public InputControlScheme BaseScemeScheme
    {
        get
        {
            if (m_BaseScemeSchemeIndex == -1) m_BaseScemeSchemeIndex = asset.FindControlSchemeIndex("BaseSceme");
            return asset.controlSchemes[m_BaseScemeSchemeIndex];
        }
    }
    public interface IBaseMapActions
    {
        void OnShoot(InputAction.CallbackContext context);
        void OnMousePos(InputAction.CallbackContext context);
    }
}
