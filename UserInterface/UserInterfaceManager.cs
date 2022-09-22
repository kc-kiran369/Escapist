using UnityEngine;
using TMPro;

public class UserInterfaceManager : MonoBehaviour
{
    [SerializeField]
    GameObject canvas;
    private void Awake()
    {
        canvas.SetActive(false);
    }
}