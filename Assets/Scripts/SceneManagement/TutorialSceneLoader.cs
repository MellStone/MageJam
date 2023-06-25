using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TutorialSceneLoader : MonoBehaviour
{
    [SerializeField] private List<string> _sceneNames;
    [SerializeField] private GameObject _loadingScreen;
    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _spawnPoint;
    [SerializeField] private EndTutorialWindow _endWindow;
    private string _activeScene = null;
    private int _tutorialLevelCounter = 0;
    private bool _isColliding;

    private void Start()
    {
        _isColliding = false;
        StartCoroutine(AsyncInitLoad(_sceneNames[_tutorialLevelCounter]));   
    }

    private void Update()
    {
        _isColliding = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (_isColliding) return;
        _isColliding = true;
        if (_tutorialLevelCounter < _sceneNames.Count - 1)
        {
            _tutorialLevelCounter++;
            StartCoroutine(AsyncSwapActiveScenes(_sceneNames[_tutorialLevelCounter]));
        }
        else if (_tutorialLevelCounter >= _sceneNames.Count - 1)
        {
            _endWindow.gameObject.SetActive(true);
            Time.timeScale = 0f;
        }
        Debug.Log("entered");

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
