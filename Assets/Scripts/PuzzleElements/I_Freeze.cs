using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class I_Freeze : IcePuzzleElement
{
    [SerializeField] private ParticleSystem _freezeEffect;
    [SerializeField] private float _rotationIncrement;
    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }
    private void FixedUpdate()
    {
        if(!isActive)
        {
            gameObject.transform.Rotate(0f, 0f, _rotationIncrement);
            _interactionParticle.gameObject.transform.Rotate(0f, 0f, -_rotationIncrement);
        }
    }
    public override void Activate()
    {
        Debug.Log("Freeze activated");
        isActive = true;
        PlayAudioClip();
        //freeze element
        _freezeEffect.Play();
    }

    public override void Deactivate()
    {
        Debug.Log("Freeze deactivated");
        isActive = false;
        //
        _freezeEffect.Stop();
    }
}
