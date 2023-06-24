using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private string _playSceneName;
    [SerializeField] private Button _playButton, _optionsButton, _quitButton; //main frame buttons
    [SerializeField] private Button _option1Button, _backButton; //options frame buttons
    [SerializeField] private Slider _volumeSlider;
    [SerializeField] private GameObject _mainFrame, _optionsFrame;

    private void Start()
    {
        _playButton.onClick.AddListener(() => { SceneManager.LoadScene(_playSceneName); });
        _optionsButton.onClick.AddListener(() => { _mainFrame.SetActive(false); _optionsFrame.SetActive(true); });
        _quitButton.onClick.AddListener(() => { Application.Quit(); });
        _option1Button.onClick.AddListener(() => { Debug.Log("option 1"); });
        _backButton.onClick.AddListener(() => { _mainFrame.SetActive(true); _optionsFrame.SetActive(false); });
    }
}
