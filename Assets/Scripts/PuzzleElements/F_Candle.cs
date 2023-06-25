using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class F_Candle : FirePuzzleElement
{
    [SerializeField] private ParticleSystem _flameParticle;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }
    public override void Activate()
    {
        Debug.Log("Candle activated");
        isActive = true;
        PlayAudioClip();
        //Start burning coroutine
        StartCoroutine(BurnCandle(_burnDuration));
        //change animation from inactive to burning
        _flameParticle.Play();
    }

    public override void Deactivate() 
    {
        Debug.Log("Candle Deactivated");
        isActive = false;
        //change animation from burning to inactive
        _flameParticle.Stop();
    }

    IEnumerator BurnCandle(float duration)
    {
        yield return new WaitForSeconds(duration);
        Deactivate();
    }
}
