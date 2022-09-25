using Cinemachine;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    [SerializeField] internal Animator animator;
    [SerializeField] CinemachineVirtualCamera v_camera;

    new Rigidbody rigidbody;

    public bool IsInputEnable { get; set; } = false;
    public float Sensitivity { get; set; } = 40.0f;
    private float playerSpeed { get; set; } = 4.0f;
    private float jumpForce { get; } = 500.0f;

    private Vector3 direction;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }
    public void ChangeTransform(Vector2 vector)
    {
        direction = new Vector3(vector.x * Time.deltaTime * playerSpeed, 0, vector.y * Time.deltaTime * playerSpeed);
        transform.Translate(direction);
        //Debug.Log("Move IT : " + vector);
    }
    public void Jump()
    {
        animator.SetTrigger("jump");
        rigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        print("jump");
    }
    public void Aim()
    {
        animator.SetTrigger("aim");
    }
    public void OnAimRelease()
    {

    }
    public void ProcessMouse(Vector2 vector)
    {
        transform.Rotate(0, vector.x * Sensitivity * Time.deltaTime, 0);
    }
}