using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private List<KeyElement> _keys = new List<KeyElement>();
    private bool _isOpened;
    [SerializeField] private Animation _anim;

    private void Awake()
    {
        _isOpened = false;
    }

    private void Update()
    {
        int counter = 0;
        foreach(KeyElement key in _keys)
        {
            if(key.isActive)
            {
                counter++;
            }
        }
        if(counter == _keys.Count && !_isOpened)
        {
            _isOpened = true;
            Open();
        }
    }

    private void Open()
    {
        Debug.Log("Door opened");
        _anim.Play();
    }
}
