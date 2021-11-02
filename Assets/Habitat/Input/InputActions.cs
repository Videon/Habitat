// GENERATED AUTOMATICALLY FROM 'Assets/Habitat/Input/InputActions.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @InputActions : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @InputActions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputActions"",
    ""maps"": [
        {
            ""name"": ""CameraControl"",
            ""id"": ""4d032912-b60c-4ece-b3c1-32c1ed04a34e"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""Value"",
                    ""id"": ""6dd5e006-69de-4bcc-b2fe-f9d9aa6e0e60"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Zoom"",
                    ""type"": ""Value"",
                    ""id"": ""3c1b2a6f-0860-4411-9943-278baafce095"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WASD"",
                    ""id"": ""5a298190-4756-492e-b875-2b488e8129bb"",
                    ""path"": ""2DVector(mode=2)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""6694c420-8eec-4616-80bd-2113ca0e2f31"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""93eb3326-dfc9-4cf1-87fe-51d9dfc8272b"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Left"",
                    ""id"": ""6c07deda-b4c2-4f28-aee8-c57afe393408"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Right"",
                    ""id"": ""5964b462-8402-48d9-855c-3c51b99fffe0"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""ee63a8a0-494a-456c-91af-dbb49d85ca3c"",
                    ""path"": ""<Mouse>/scroll/y"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Zoom"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Interaction"",
            ""id"": ""06b5e420-3714-4fd4-b197-e2fe3e332482"",
            ""actions"": [
                {
                    ""name"": ""Primary"",
                    ""type"": ""Button"",
                    ""id"": ""025a58da-403e-47b2-885a-12cad0f06ac8"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Secondary"",
                    ""type"": ""Button"",
                    ""id"": ""ad9efa1b-0606-4034-9c7d-85c69cc6e3ab"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""SelectBuildingOne"",
                    ""type"": ""Button"",
                    ""id"": ""b30a2ae5-8881-4660-9256-998dfcff5e46"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""SelectBuildingTwo"",
                    ""type"": ""Button"",
                    ""id"": ""e9c4e224-07e2-4d5a-a7b0-f502c9aef9e2"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""330d898f-bc5b-4879-a7f8-bbce4607e91d"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Primary"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""60fdb94d-841d-4c16-a8ab-3f79f8c0f768"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Secondary"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c3f43cd6-e4a8-4b61-a7e9-eac4e536818c"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SelectBuildingOne"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""019f81fb-9033-4d92-bfd5-f9f6c54525d3"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SelectBuildingTwo"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Menu"",
            ""id"": ""8fb46a82-62b1-4c14-a114-03ac638c620c"",
            ""actions"": [
                {
                    ""name"": ""Select"",
                    ""type"": ""Value"",
                    ""id"": ""f6ceac8e-961f-40db-8790-5f378472b05d"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WASD"",
                    ""id"": ""0654f4f5-2ead-4381-9c44-f1947419cb98"",
                    ""path"": ""2DVector(mode=2)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Select"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""8d8decbb-76c3-46bd-ac22-6e082d9bd37f"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Select"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""e78eec71-5deb-4788-b187-2ec4270ad2ea"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Select"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Left"",
                    ""id"": ""55d9f7e8-ca2c-4913-b0e1-55e4f7cad0a6"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Select"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Right"",
                    ""id"": ""09befa9a-5a34-4ed5-9e36-41a4db4f9476"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Select"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // CameraControl
        m_CameraControl = asset.FindActionMap("CameraControl", throwIfNotFound: true);
        m_CameraControl_Movement = m_CameraControl.FindAction("Movement", throwIfNotFound: true);
        m_CameraControl_Zoom = m_CameraControl.FindAction("Zoom", throwIfNotFound: true);
        // Interaction
        m_Interaction = asset.FindActionMap("Interaction", throwIfNotFound: true);
        m_Interaction_Primary = m_Interaction.FindAction("Primary", throwIfNotFound: true);
        m_Interaction_Secondary = m_Interaction.FindAction("Secondary", throwIfNotFound: true);
        m_Interaction_SelectBuildingOne = m_Interaction.FindAction("SelectBuildingOne", throwIfNotFound: true);
        m_Interaction_SelectBuildingTwo = m_Interaction.FindAction("SelectBuildingTwo", throwIfNotFound: true);
        // Menu
        m_Menu = asset.FindActionMap("Menu", throwIfNotFound: true);
        m_Menu_Select = m_Menu.FindAction("Select", throwIfNotFound: true);
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

    // CameraControl
    private readonly InputActionMap m_CameraControl;
    private ICameraControlActions m_CameraControlActionsCallbackInterface;
    private readonly InputAction m_CameraControl_Movement;
    private readonly InputAction m_CameraControl_Zoom;
    public struct CameraControlActions
    {
        private @InputActions m_Wrapper;
        public CameraControlActions(@InputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_CameraControl_Movement;
        public InputAction @Zoom => m_Wrapper.m_CameraControl_Zoom;
        public InputActionMap Get() { return m_Wrapper.m_CameraControl; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(CameraControlActions set) { return set.Get(); }
        public void SetCallbacks(ICameraControlActions instance)
        {
            if (m_Wrapper.m_CameraControlActionsCallbackInterface != null)
            {
                @Movement.started -= m_Wrapper.m_CameraControlActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_CameraControlActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_CameraControlActionsCallbackInterface.OnMovement;
                @Zoom.started -= m_Wrapper.m_CameraControlActionsCallbackInterface.OnZoom;
                @Zoom.performed -= m_Wrapper.m_CameraControlActionsCallbackInterface.OnZoom;
                @Zoom.canceled -= m_Wrapper.m_CameraControlActionsCallbackInterface.OnZoom;
            }
            m_Wrapper.m_CameraControlActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @Zoom.started += instance.OnZoom;
                @Zoom.performed += instance.OnZoom;
                @Zoom.canceled += instance.OnZoom;
            }
        }
    }
    public CameraControlActions @CameraControl => new CameraControlActions(this);

    // Interaction
    private readonly InputActionMap m_Interaction;
    private IInteractionActions m_InteractionActionsCallbackInterface;
    private readonly InputAction m_Interaction_Primary;
    private readonly InputAction m_Interaction_Secondary;
    private readonly InputAction m_Interaction_SelectBuildingOne;
    private readonly InputAction m_Interaction_SelectBuildingTwo;
    public struct InteractionActions
    {
        private @InputActions m_Wrapper;
        public InteractionActions(@InputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Primary => m_Wrapper.m_Interaction_Primary;
        public InputAction @Secondary => m_Wrapper.m_Interaction_Secondary;
        public InputAction @SelectBuildingOne => m_Wrapper.m_Interaction_SelectBuildingOne;
        public InputAction @SelectBuildingTwo => m_Wrapper.m_Interaction_SelectBuildingTwo;
        public InputActionMap Get() { return m_Wrapper.m_Interaction; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(InteractionActions set) { return set.Get(); }
        public void SetCallbacks(IInteractionActions instance)
        {
            if (m_Wrapper.m_InteractionActionsCallbackInterface != null)
            {
                @Primary.started -= m_Wrapper.m_InteractionActionsCallbackInterface.OnPrimary;
                @Primary.performed -= m_Wrapper.m_InteractionActionsCallbackInterface.OnPrimary;
                @Primary.canceled -= m_Wrapper.m_InteractionActionsCallbackInterface.OnPrimary;
                @Secondary.started -= m_Wrapper.m_InteractionActionsCallbackInterface.OnSecondary;
                @Secondary.performed -= m_Wrapper.m_InteractionActionsCallbackInterface.OnSecondary;
                @Secondary.canceled -= m_Wrapper.m_InteractionActionsCallbackInterface.OnSecondary;
                @SelectBuildingOne.started -= m_Wrapper.m_InteractionActionsCallbackInterface.OnSelectBuildingOne;
                @SelectBuildingOne.performed -= m_Wrapper.m_InteractionActionsCallbackInterface.OnSelectBuildingOne;
                @SelectBuildingOne.canceled -= m_Wrapper.m_InteractionActionsCallbackInterface.OnSelectBuildingOne;
                @SelectBuildingTwo.started -= m_Wrapper.m_InteractionActionsCallbackInterface.OnSelectBuildingTwo;
                @SelectBuildingTwo.performed -= m_Wrapper.m_InteractionActionsCallbackInterface.OnSelectBuildingTwo;
                @SelectBuildingTwo.canceled -= m_Wrapper.m_InteractionActionsCallbackInterface.OnSelectBuildingTwo;
            }
            m_Wrapper.m_InteractionActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Primary.started += instance.OnPrimary;
                @Primary.performed += instance.OnPrimary;
                @Primary.canceled += instance.OnPrimary;
                @Secondary.started += instance.OnSecondary;
                @Secondary.performed += instance.OnSecondary;
                @Secondary.canceled += instance.OnSecondary;
                @SelectBuildingOne.started += instance.OnSelectBuildingOne;
                @SelectBuildingOne.performed += instance.OnSelectBuildingOne;
                @SelectBuildingOne.canceled += instance.OnSelectBuildingOne;
                @SelectBuildingTwo.started += instance.OnSelectBuildingTwo;
                @SelectBuildingTwo.performed += instance.OnSelectBuildingTwo;
                @SelectBuildingTwo.canceled += instance.OnSelectBuildingTwo;
            }
        }
    }
    public InteractionActions @Interaction => new InteractionActions(this);

    // Menu
    private readonly InputActionMap m_Menu;
    private IMenuActions m_MenuActionsCallbackInterface;
    private readonly InputAction m_Menu_Select;
    public struct MenuActions
    {
        private @InputActions m_Wrapper;
        public MenuActions(@InputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Select => m_Wrapper.m_Menu_Select;
        public InputActionMap Get() { return m_Wrapper.m_Menu; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MenuActions set) { return set.Get(); }
        public void SetCallbacks(IMenuActions instance)
        {
            if (m_Wrapper.m_MenuActionsCallbackInterface != null)
            {
                @Select.started -= m_Wrapper.m_MenuActionsCallbackInterface.OnSelect;
                @Select.performed -= m_Wrapper.m_MenuActionsCallbackInterface.OnSelect;
                @Select.canceled -= m_Wrapper.m_MenuActionsCallbackInterface.OnSelect;
            }
            m_Wrapper.m_MenuActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Select.started += instance.OnSelect;
                @Select.performed += instance.OnSelect;
                @Select.canceled += instance.OnSelect;
            }
        }
    }
    public MenuActions @Menu => new MenuActions(this);
    public interface ICameraControlActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnZoom(InputAction.CallbackContext context);
    }
    public interface IInteractionActions
    {
        void OnPrimary(InputAction.CallbackContext context);
        void OnSecondary(InputAction.CallbackContext context);
        void OnSelectBuildingOne(InputAction.CallbackContext context);
        void OnSelectBuildingTwo(InputAction.CallbackContext context);
    }
    public interface IMenuActions
    {
        void OnSelect(InputAction.CallbackContext context);
    }
}
