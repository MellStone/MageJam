using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private List<KeyElement> _keys = new List<KeyElement>();
    private bool _isOpened;
    [SerializeField] private Animation _anim;
    [SerializeField] private List<Collider> _colliders = new List<Collider>();


    private void Awake()
    {
        _isOpened = false;
        foreach(Collider collider in _colliders)
        {
            collider.enabled = true;
        }
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
        foreach(Collider collider in _colliders) 
        {
            collider.enabled = false;
        }
    }
}
