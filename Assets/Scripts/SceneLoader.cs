using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public static SceneLoader instance;

    public static bool IsSceneLoaderLoaded = false;

    private void Awake()
    {
        if (!IsSceneLoaderLoaded)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);
    }

    private void Start()
    {
        if (!IsSceneLoaderLoaded)
        {
            LoadScene(1);
            IsSceneLoaderLoaded = true;
        }
    }

    private int _currentLoadSceneIndex = 0;

    public void LoadScene(int SceneIndex)
    {
        _currentLoadSceneIndex = SceneIndex;
        StartLoadSceneLoader();
    }

    public void ReloadScene()
    {
        LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void StartLoadSceneLoader()
    {
        SceneManager.LoadScene(0);
        StartCoroutine(StartLoadCurrentScene());
    }

    private IEnumerator StartLoadCurrentScene()
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(_currentLoadSceneIndex);
        while (!operation.isDone)
            yield return new WaitForEndOfFrame();
    }
}
