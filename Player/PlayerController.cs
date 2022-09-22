using UnityEngine;
using TMPro;
using Cinemachine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    TMP_Text text;

    new Rigidbody rigidbody;

    private float floatX, floatZ;
    public bool IsInputEnable { get; set; } = true;
    public float Sensitivity { get; set; } = 40.0f;
    private float playerSpeed { get; set; } = 4.0f;
    private float jumpForce { get; set; } = 20000.0f;

    private Vector3 direction;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    public void ProcessInput()
    {
        floatX = Input.GetAxis("Horizontal");
        floatZ = Input.GetAxis("Vertical");
    }

    public void ChangeTransform()
    {
        direction = new Vector3(floatX * Time.deltaTime * playerSpeed, 0, floatZ * Time.deltaTime * playerSpeed);
        transform.Translate(direction);
        text.text = "Velocity : " + rigidbody.velocity;
    }
    public void Jump()
    {
        rigidbody.AddForce(Vector3.up * jumpForce);
    }

    public void ProcessMouse()
    {
        transform.Rotate(0, Input.GetAxis("Mouse X") * Sensitivity * Time.deltaTime, 0);
    }
}