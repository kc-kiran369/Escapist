using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class MainMenuUIHandeler : MonoBehaviour
{
    [SerializeField] GameObject map, joinMenu;
    [SerializeField] Button hostButton, joinButton;
    [SerializeField] TMP_Text selectedMapText;
    [SerializeField] LevelManager levelManager;

    int selectedMap = 0;

    private void OnEnable()
    {
        map.SetActive(false);
        joinMenu.SetActive(false);
    }

    public void OnHostClicked()
    {
        SelectMap();
    }
    public void OnJoinClicked()
    {
        JoinConfig();
    }
    public void OnStartClicked()
    {
        if (selectedMap > 0 && selectedMap < 4)
            LoadScene(selectedMap);
    }

    public void DefineMapIndex(int index)
    {
        selectedMap = index;
        switch (selectedMap)
        {
            case 1:
                selectedMapText.text = "Selected Map : School";
                break;
            case 2:
                selectedMapText.text = "Selected Map : Not Declared";
                break;
            case 3:
                selectedMapText.text = "Selected Map : Training";
                break;
            default:
                selectedMapText.text = "Selected Map : None";
                break;
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    private void SelectMap()
    {
        if (map.activeSelf)
        {
            map.SetActive(false);
            joinButton.interactable = true;
        }
        else
        {
            map.SetActive(true);
            joinButton.interactable = false;
        }
    }

    private void JoinConfig()
    {
        if (joinMenu.activeSelf)
        {
            joinMenu.SetActive(false);
            hostButton.interactable = true;
        }
        else
        {
            joinMenu.SetActive(true);
            hostButton.interactable = false;
        }
    }

    private void LoadScene(int BuildIndex)
    {
        levelManager.LoadScene(selectedMap);
    }
}