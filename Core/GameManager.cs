using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] PlayerController controller;
    [SerializeField] GameObject userInterface;
    [SerializeField] UserInterfaceManager userInterfacemanager;

    public void PauseMenu()
    {
        if (userInterface.activeSelf)
        {
            Cursor.lockState = CursorLockMode.Locked;
            controller.IsInputEnable = true;
            userInterface.SetActive(false);
            userInterfacemanager.ToggleSettings(false);
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
        Debug.Log("Exit.....");
        Application.Quit();
    }
}