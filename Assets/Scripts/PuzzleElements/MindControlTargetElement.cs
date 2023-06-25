using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MindControlTargetElement : MonoBehaviour
{
    public bool isActive;
    private ParticleSystem _particle;

    private void Start()
    {
        _particle= GetComponentInChildren<ParticleSystem>();
    }

    public void Activate()
    {
        isActive = true;
        _particle.Play();
    }

    public void Deactivate()
    {
        isActive = false;
        _particle.Stop();
    }
}
