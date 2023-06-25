using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private string _mainMenuSceneName;
    [SerializeField] private Button _resumeButton, _quitButton;
    [SerializeField] private GameObject _pauseWindow;

    private void Start()
    {
        _resumeButton.onClick.AddListener(() => { _pauseWindow.SetActive(false); Time.timeScale = 1.0f; });
        _quitButton.onClick.AddListener(() => { SceneManager.LoadScene(_mainMenuSceneName); Time.timeScale = 1.0f; });
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            _pauseWindow.SetActive(true); 
            Time.timeScale = 0f;
        }
    }
}
