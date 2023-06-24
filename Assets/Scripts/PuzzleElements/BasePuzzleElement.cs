using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BasePuzzleElement : MonoBehaviour
{
    public bool isActive;
    //[SerializeField] protected animations
    protected AudioSource _audioSource;

    protected ParticleSystem _particle;

    public abstract void Activate();

    public abstract void Deactivate();

    protected void PlayAudioClip()
    {
        _audioSource.Play();
    }

    protected void StartParticles()
    {
        _particle.Play();
    }

    protected void StopParticles()
    {
        _particle.Stop();
    }
}
