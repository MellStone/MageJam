using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private string _tutorialSceneName, _normalSceneName;
    [SerializeField] private Button _playButton, _optionsButton, _quitButton; //main frame buttons
    [SerializeField] private Button _option1Button, _optionBackButton; //options frame buttons
    [SerializeField] private Button _tutorialButton, _normalButton, _playBackButton; //play frame buttons
    [SerializeField] private Slider _volumeSlider;
    [SerializeField] private GameObject _mainFrame, _optionsFrame, _playFrame;

    private void Start()
    {
        _playButton.onClick.AddListener(() => { _playFrame.SetActive(true); _mainFrame.SetActive(false); });
        _optionsButton.onClick.AddListener(() => { _mainFrame.SetActive(false); _optionsFrame.SetActive(true); });
        _quitButton.onClick.AddListener(() => { Application.Quit(); });

        _option1Button.onClick.AddListener(() => { Debug.Log("option 1"); });
        _optionBackButton.onClick.AddListener(() => { _mainFrame.SetActive(true); _optionsFrame.SetActive(false); });

        _tutorialButton.onClick.AddListener(() => { SceneManager.LoadScene(_tutorialSceneName); });
        _normalButton.onClick.AddListener(() => { SceneManager.LoadScene(_normalSceneName); });
        _playBackButton.onClick.AddListener(() => { _mainFrame.SetActive(true); _playFrame.SetActive(false); });


    }
}
