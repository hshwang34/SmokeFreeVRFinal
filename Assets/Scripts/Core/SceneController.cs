using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public static SceneController Instance { get; private set; }

    private SceneTransition _sceneTransition;

    private void Awake()
    {
        InitializeSingleton();
        InitializeSceneTransition();
    }

    private void InitializeSingleton()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void InitializeSceneTransition()
    {
        _sceneTransition = GetComponent<SceneTransition>();
    }

    public void ReturnToMainScene()
    {
        LoadSceneByIndex(0);
    }

    public void ShowClubCessationScene()
    {
        if (_sceneTransition != null)
        {
            _sceneTransition.FadeAndLoadScene(2);
        }
    }

    public void ShowLungVisualizationScene()
    {
        if (_sceneTransition != null)
        {
            _sceneTransition.FadeAndLoadScene(1);
        }
    }

    public void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = (currentSceneIndex + 1) % SceneManager.sceneCountInBuildSettings;
        SceneManager.LoadScene(nextSceneIndex);
    }

    public void LoadSceneByName(string sceneName)
    {
        if (string.IsNullOrEmpty(sceneName)) return;
        
        Scene scene = SceneManager.GetSceneByName(sceneName);
        if (scene.IsValid())
        {
            SceneManager.LoadScene(sceneName);
        }
    }

    public void LoadSceneByIndex(int index)
    {
        if (IsValidSceneIndex(index))
        {
            SceneManager.LoadScene(index);
        }
    }

    public void ReloadCurrentScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        LoadSceneByIndex(currentSceneIndex);
    }

    private bool IsValidSceneIndex(int index)
    {
        return index >= 0 && index < SceneManager.sceneCountInBuildSettings;
    }
}
