using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class InputHandeler : MonoBehaviour
{
    [SerializeField] PlayerController player;
    [SerializeField] GamePlayManager gameManager;
    //Ref to New Input Asset
    public InputMaster input;

    void Awake()
    {
        input = new InputMaster();
        input.Game.Quit.performed += OnEscapePressed;
        input.PlayerAction.Jump.performed += OnSpacePressed;
        input.PlayerAction.Aim.performed += OnMouseRightPressed;
        input.PlayerAction.Shoot.performed += OnMouseLeftPressed;
        input.PlayerAction.Move.performed += context => OnMovement(context.ReadValue<Vector2>());
        input.PlayerAction.Mouse.performed += context1 => OnMousePositionChanged(context1.ReadValue<Vector2>());
    }

    private void Update()
    {
        if (player.IsInputEnable)
            OnMovement(input.PlayerAction.Move.ReadValue<Vector2>());
    }
    void OnSpacePressed(InputAction.CallbackContext context)
    {
        player.Jump();
    }
    void OnEscapePressed(InputAction.CallbackContext context)
    {
        gameManager.PauseMenu();
    }
    void OnMovement(Vector2 vector)
    {
        player.ChangeTransform(vector, input);
    }
    void OnMousePositionChanged(Vector2 vector)
    {
        if (player.IsInputEnable)
            player.ProcessMouse(vector);
    }
    void OnMouseLeftPressed(InputAction.CallbackContext context)
    {
        player.Shoot();
    }
    void OnMouseRightPressed(InputAction.CallbackContext context)
    {
        player.Aim();
    }
    private void OnEnable()
    {
        input.Enable();
    }
    private void OnDisable()
    {
        input.Disable();
    }
}