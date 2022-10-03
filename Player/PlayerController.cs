using Cinemachine;
using UnityEngine;
using TMPro;
public class PlayerController : MonoBehaviour
{
    [SerializeField] internal Animator animator;
    [SerializeField] CinemachineVirtualCamera v_camera;

    public Gun gun;
    public bool IsInputEnable { get; set; } = true;
    public float Sensitivity { get; set; } = 5.0f;

    private bool isAim = false;

    public void ChangeTransform(Vector2 vector, InputMaster input)
    {
        if (input.PlayerAction.Move.WasPressedThisFrame())
        {
            animator.SetBool("canRun", true);
            Debug.Log("run anim");
        }
        if (input.PlayerAction.Move.WasReleasedThisFrame())
        {
            animator.SetBool("canRun", false);
            Debug.Log("dont run anim");
        }
        animator.SetBool("turnRight", (vector.x > 0.8f ? true : false));
        animator.SetBool("turnLeft", (vector.x < -0.8f ? true : false));
    }
    public void Jump()
    {
        animator.SetTrigger("jump");
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