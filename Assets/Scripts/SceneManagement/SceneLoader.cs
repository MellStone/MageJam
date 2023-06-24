using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] private string[] _sceneNames;
    private string _activeScene = null;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.P)) //testing
        {
            if(_activeScene == null)
            {
                LoadAdditiveScene(ChooseRandomScene());
            }
            else 
            {
                UnloadAdditiveScene(_activeScene);
            }
        }
    }

    public string ChooseRandomScene()
    {
        string chosenScene = _sceneNames[Random.Range(0, _sceneNames.Length)];
        return chosenScene;
    }
    public void LoadAdditiveScene(string name)
    {
        SceneManager.LoadScene(name, LoadSceneMode.Additive);
        _activeScene = name;
    }

    public void UnloadAdditiveScene(string name)
    {
        SceneManager.UnloadScene(name);
        _activeScene = null;
    }
}
