using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_ObjectControl : ShadowPuzzleElement
{
    [SerializeField] private float _rotationIncrement;
    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _particle = GetComponentInChildren<ParticleSystem>();
    }
    private void FixedUpdate()
    {
        if (isActive)
        {
            gameObject.transform.Rotate(0f, 0f, _rotationIncrement);
            _interactionParticle.gameObject.transform.Rotate(0f, 0f, -_rotationIncrement);
        }
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
