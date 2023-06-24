using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class I_IceBlock : IcePuzzleElement
{
    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }
    public override void Activate()
    {
        Debug.Log("Ice Block activated");
        isActive = true;
        PlayAudioClip();
        //spawn ice block
    }

    public override void Deactivate()
    {
        Debug.Log("Ice Block deactivated");
        isActive = false;
        //melt ice block
    }
}
