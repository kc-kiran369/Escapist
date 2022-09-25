using UnityEngine;

public class UserInterfaceManager : MonoBehaviour
{
    [SerializeField] GameObject canvas;
    [SerializeField] GameObject SettingsPanel;

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

    public void SetQuality(int index)
    {
        QualitySettings.SetQualityLevel(index);
        Debug.Log("Quality Setting to : " + index);
    }
}