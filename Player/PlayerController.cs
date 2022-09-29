using Cinemachine;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] internal Animator animator;
    [SerializeField] CinemachineVirtualCamera v_camera;

    public Gun gun;

    new Rigidbody rigidbody;

    public bool IsInputEnable { get; set; } = false;
    public float Sensitivity { get; set; } = 5.0f;

    private float jumpForce = 300.0f;
    private Vector3 direction;
    private bool isAim = false;
    private float playerSpeed = 3.0f;

    private bool turnLeft = false, turnRight = false;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }
    public void ChangeTransform(Vector2 vector, InputMaster input)
    {
        direction = new Vector3(vector.x * Time.deltaTime * playerSpeed, 0, vector.y * Time.deltaTime * playerSpeed);
        if (vector.x >= 0.5f)
        {
            turnLeft = true;
            animator.SetBool("turnLeft", turnLeft);
        }
        if (vector.x <= 0.5f)
        {
            turnLeft = false;
            animator.SetBool("turnLeft", turnLeft);
        }
        if (input.PlayerAction.Move.WasPressedThisFrame())
        {
            animator.SetBool("canRun", true);
           
        }
        if (input.PlayerAction.Move.WasReleasedThisFrame())
        {
            animator.SetBool("canRun", false);
        }
        transform.Translate(direction);
        Debug.Log(vector);
    }
    public void Jump()
    {
        animator.SetTrigger("jump");
        //rigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        print("jump");
    }
    public void Aim()
    {
        if (!isAim)
            isAim = true;
        else
            isAim = false;
        animator.SetBool("aim", isAim);
    }
    public void Shoot()
    {
        if (!isAim)
            return;
        gun.Fire();
    }
    public void ProcessMouse(Vector2 vector)
    {
        transform.Rotate(0, vector.x * Sensitivity * Time.deltaTime, 0);
    }
}