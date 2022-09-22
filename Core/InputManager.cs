using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField]
    PlayerController player;
    [SerializeField]
    GameManager gameManager;
    void Update()
    {
        if (player.IsInputEnable)
        {
            player.ProcessInput();
            player.ProcessMouse();
            player.ChangeTransform();
            if (Input.GetKeyDown(KeyCode.Space))
            {
                player.Jump();
                Debug.Log("Jump");
            }
        }
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            gameManager.PauseMenu();
        }
    }
}