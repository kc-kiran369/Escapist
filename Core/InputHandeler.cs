using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandeler : MonoBehaviour
{
    [SerializeField] PlayerController player;
    [SerializeField] GamePlayManager gameManager;
    //Ref to New Input Asset
    public InputMaster input;

    void Awake()
    {
        input = new InputMaster();
        input.PlayerAction.Jump.performed += ctx => OnSpacePressed();
        input.Game.Quit.performed += ctx1 => OnEscapePressed();
        input.PlayerAction.Move.performed += ctx2 => OnMovement(ctx2.ReadValue<Vector2>());
        input.PlayerAction.Mouse.performed += ctx3 => OnMousePositionChanged(ctx3.ReadValue<Vector2>());
        input.PlayerAction.Shoot.performed += ctx4 => OnMouseLeftPressed();
        input.PlayerAction.Aim.performed += ctx4 => OnMouseRightPressed();
    }

    private void Update()
    {
        OnMovement(input.PlayerAction.Move.ReadValue<Vector2>());
        OnMousePositionChanged(input.PlayerAction.Mouse.ReadValue<Vector2>());
    }
    void OnSpacePressed()
    {
        player.Jump();
    }
    void OnEscapePressed()
    {
        gameManager.PauseMenu();
    }
    void OnMovement(Vector2 vector)
    {
        player.ChangeTransform(vector, input);
    }
    void OnMousePositionChanged(Vector2 vector)
    {
        player.ProcessMouse(vector);
    }
    void OnMouseLeftPressed()
    {
        player.Shoot();
    }
    void OnMouseRightPressed()
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