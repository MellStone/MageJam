using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] private string[] _sceneNames;
    [SerializeField] private GameObject _loadingScreen;
    [SerializeField] private GameObject _player;
    private string _activeScene = null;

    private void Start()
    {
        StartCoroutine(AsyncInitLoad(ChooseRandomScene()));
    } 

    private void OnTriggerEnter(Collider other)
    {
        StartCoroutine(AsyncSwapActiveScenes(ChooseRandomScene()));
    }

    public string ChooseRandomScene()
    {
        string chosenScene = _sceneNames[Random.Range(0, _sceneNames.Length)];
        return chosenScene;
    }

    IEnumerator AsyncInitLoad(string name)
    {
        _loadingScreen.SetActive(true);
        _activeScene = name;
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(name, LoadSceneMode.Additive);
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
        _loadingScreen.SetActive(false);
    }

    IEnumerator AsyncSwapActiveScenes(string newSceneName)
    {
        _loadingScreen.SetActive(true);
        _player.transform.position = Vector3.zero;
        //unload scene
        AsyncOperation asyncUnload = SceneManager.UnloadSceneAsync(_activeScene);
        while (!asyncUnload.isDone)
        {
            yield return null;
        }
        //load scene
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(newSceneName, LoadSceneMode.Additive);
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
        _activeScene = newSceneName;
        _loadingScreen.SetActive(false);
    }
}
