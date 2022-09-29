using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUIHandeler : MonoBehaviour
{
    public void LoadScene(int BuildIndex)
    {
        SceneManager.LoadScene(BuildIndex);
    }
}