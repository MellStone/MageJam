using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndTutorialWindow : MonoBehaviour
{
    [SerializeField] private string _mainMenuSceneName, _normalSceneName;
    [SerializeField] private Button _playButton, _quitButton;

    private void Start()
    {
        _playButton.onClick.AddListener(() => { SceneManager.LoadScene(_normalSceneName); Time.timeScale = 1.0f; });
        _quitButton.onClick.AddListener(() => { SceneManager.LoadScene(_mainMenuSceneName); Time.timeScale = 1.0f; });
    }
}
