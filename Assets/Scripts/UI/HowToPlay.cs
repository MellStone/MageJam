using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HowToPlay : MonoBehaviour
{
    [SerializeField] private GameObject _howToPlayWindow;
    [SerializeField] private string _sceneToLoad;

    private void Awake()
    {
        _howToPlayWindow.SetActive(true);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            _howToPlayWindow.SetActive(false);
            SceneManager.LoadScene(_sceneToLoad);
        }
    }
}
