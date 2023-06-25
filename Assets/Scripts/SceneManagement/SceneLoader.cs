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
    [SerializeField] private GameObject _spawnPoint;
    private string _activeScene = null;
    private bool _isColliding;

    private void Start()
    {
        _isColliding = false;
        StartCoroutine(AsyncInitLoad(ChooseRandomScene()));
    }

    private void Update()
    {
        _isColliding = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (_isColliding) return;
        _isColliding = true;
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
        _player.transform.position = _spawnPoint.transform.position;
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
