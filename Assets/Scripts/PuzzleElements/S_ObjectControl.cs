using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_ObjectControl : ShadowPuzzleElement
{
    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _particle = GetComponentInChildren<ParticleSystem>();
    }
    public override void Activate()
    {
        Debug.Log("Object Control activated");
        isActive = true;
        PlayAudioClip();
        StartParticles();
    }

    public override void Deactivate()
    {
        Debug.Log("Object Control deactivated");
        isActive = false;
        StopParticles();
    }
}
