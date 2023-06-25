using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class I_IceBlock : IcePuzzleElement
{
    [SerializeField] private GameObject _iceBlock;
    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _iceBlock.SetActive(isActive);
    }
    public override void Activate()
    {
        Debug.Log("Ice Block activated");
        isActive = true;
        PlayAudioClip();
        //spawn ice block
        _iceBlock.SetActive(isActive);
    }

    public override void Deactivate()
    {
        Debug.Log("Ice Block deactivated");
        isActive = false;
        //melt ice block
        _iceBlock.SetActive(isActive);
    }
}
