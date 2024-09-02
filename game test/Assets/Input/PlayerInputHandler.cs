using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{
    [Header("Input Action")]
    [SerializeField] private InputActionAsset playerControls;

    [Header("Map Name Refrences")]
    [SerializeField] private string actionMapName = "Player";

    [Header("Input Name Refrences")]
    [SerializeField] private string move = "Move";
    [SerializeField] private string look = "Look";
    [SerializeField] private string sprint = "Sprint";
    [SerializeField] private string attack = "Attack";

    private InputAction moveAction;
    private InputAction lookAction;
    private InputAction sprintAction;
    private InputAction attackAction;

    public Vector2 MoveInput { get; private set; }
    public Vector2 LookInput { get; private set; }
    public bool SprintInput { get; private set; }
    public bool AttackInput { get; private set; }

    public static PlayerInputHandler instance { get; private set; }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        moveAction = playerControls.FindActionMap(actionMapName).FindAction(move);
        lookAction = playerControls.FindActionMap(actionMapName).FindAction(look);
        sprintAction = playerControls.FindActionMap(actionMapName).FindAction(sprint);
        attackAction = playerControls.FindActionMap(actionMapName).FindAction(attack);
        RegisterInputActions();
    }

    void RegisterInputActions()
    {
        moveAction.performed += context => MoveInput = context.ReadValue<Vector2>();
        moveAction.canceled += context => MoveInput = Vector2.zero;

        lookAction.performed += context => LookInput = context.ReadValue<Vector2>();
        lookAction.canceled += context => LookInput = Vector2.zero;

        sprintAction.performed += context => SprintInput = true;
        sprintAction.canceled += context => SprintInput = false;
    }

    private void OnEnable()
    {
        moveAction.Enable();
        lookAction.Enable();
        attackAction.Enable();
        sprintAction.Enable();
    }

    private void OnDisable()
    {
        moveAction.Disable();
        lookAction.Disable();
        attackAction.Disable();
        sprintAction.Disable();
    }
}
