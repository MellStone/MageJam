using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_ObjectControl : ShadowPuzzleElement
{
    public override void Activate()
    {
        Debug.Log("Object Control activated");
        isActive = true;
        PlayAudioClip();
    }

    public override void Deactivate()
    {
        Debug.Log("Object Control deactivated");
        isActive = false;
    }
}
