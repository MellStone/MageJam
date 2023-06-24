using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BasePuzzleElement : MonoBehaviour
{
    public bool isActive;
    //[SerializeField] protected animations
    protected AudioSource _audioSource;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public abstract void Activate();

    public abstract void Deactivate();

    protected void PlayAudioClip()
    {
        _audioSource.Play();
    }
}
