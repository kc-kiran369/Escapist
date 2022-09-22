using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    PlayerController controller;
    [SerializeField]
    GameObject userInterface;

    void Awake()
    {

    }

    public void PauseMenu()
    {
        if (userInterface.activeSelf)
        {
            Cursor.lockState = CursorLockMode.Locked;
            controller.IsInputEnable = true;
            userInterface.SetActive(false);
            Debug.Log("UserInterface Disabled");
        }
        else
        {
            Cursor.lockState = CursorLockMode.Confined;
            controller.IsInputEnable = false;
            userInterface.SetActive(true);
            Debug.Log("UserInterface Enabled");
        }
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}