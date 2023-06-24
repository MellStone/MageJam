using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_MindControl : ShadowPuzzleElement
{
    [SerializeField] private MindControlTargetElement _elementToActivate;  //can be made public if we want player to choose element to activate
    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public override void Activate()
    {
        Debug.Log("Mind Control activated");
        isActive = true;
        PlayAudioClip();
        _elementToActivate.Activate();
        //make npc channel
    }

    public override void Deactivate()
    {
        Debug.Log("Mind Control deactivated");
        isActive = false;
        _elementToActivate.Deactivate();
        //stop npc channel
    }
}
