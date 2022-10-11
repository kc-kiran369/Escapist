using Cinemachine;
using UnityEngine;
public class PlayerController : MonoBehaviour
{
    [SerializeField] internal Animator m_Animator;
    [SerializeField] CinemachineVirtualCamera m_AimCam;
    [SerializeField] Gun m_Gun;
    public bool IsInputEnable { get; set; } = true;
    public float Sensitivity { get; set; } = 1.0f;

    private float m_SensitivityMultiplier = 5.0f;
    private bool isAim = false;
    private void Start()
    {
        m_Animator = GetComponent<Animator>();
    }
    public void ChangeTransform(Vector2 vector, InputMaster input)
    {
        m_Animator.SetBool("turnRight", (vector.x > 0.7f ? true : false));
        m_Animator.SetBool("turnLeft", (vector.x < -0.7f ? true : false));
        m_Animator.SetBool("canRun", (vector.y > 0.8f ? true : false));
    }
    public void Jump()
    {
        m_Animator.SetTrigger("jump");
    }
    public void Aim()
    {
        if (!isAim)
        {
            isAim = true;
            m_AimCam.gameObject.SetActive(true);
        }
        else
        {
            isAim = false;
            m_AimCam.gameObject.SetActive(false);
        }
        m_Animator.SetBool("aim", isAim);
    }
    public void Shoot()
    {
        if (!isAim)
            return;
        m_Gun?.Fire();
    }
    public void ProcessMouse(Vector2 vector)
    {
        transform.Rotate(0, vector.x * Sensitivity * m_SensitivityMultiplier * Time.deltaTime, 0);
    }
}