using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class I_Freeze : IcePuzzleElement
{
    public override void Activate()
    {
        Debug.Log("Freeze activated");
        isActive = true;
        PlayAudioClip();
        //freeze element
    }

    public override void Deactivate()
    {
        Debug.Log("Freeze deactivated");
        isActive = false;
        //
    }
}
