using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    [SerializeField] GameObject loadingUI;
    [SerializeField] Image loadingBar;

    public static LevelManager Instance;
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        loadingUI.SetActive(false);
    }

    public void LoadScene(int BuildIndex)
    {
        loadingUI.SetActive(true);
        var scene = SceneManager.LoadSceneAsync(BuildIndex);
        scene.allowSceneActivation = false;
        do
        {
            loadingBar.rectTransform.localScale += new Vector3(scene.progress * Time.deltaTime, 1.0f, 1.0f);
        } while (scene.progress < 0.9f);
        loadingUI.SetActive(false);
        scene.allowSceneActivation = true;
    }
}