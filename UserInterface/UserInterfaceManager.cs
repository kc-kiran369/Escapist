using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class UserInterfaceManager : MonoBehaviour
{
    [SerializeField] GameObject canvas;
    [SerializeField] GameObject SettingsPanel;
    [SerializeField] TMP_Dropdown m_GraphicDropdown;

    private void Awake()
    {
        canvas.SetActive(false);
        SettingsPanel.SetActive(false);
    }

    public void ToggleSettings(bool isActive)
    {
        SettingsPanel.SetActive(isActive);
        Debug.Log("Toggle : Setting Panel");
    }

    public void SetQuality()
    {
        QualitySettings.SetQualityLevel(m_GraphicDropdown.value);
        Debug.Log("Quality Setting to : " + m_GraphicDropdown.value);
    }
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
}