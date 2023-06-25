using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class S_MindControl : ShadowPuzzleElement
{
    [SerializeField] private MindControlTargetElement _elementToActivate;  //can be made public if we want player to choose element to activate
    [SerializeField] private List<string> _textLines;
    [SerializeField] private TextMeshProUGUI _textBox;
    [SerializeField] private float _textDisplayTime;
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
        if(_textLines != null ) 
        {
            //display random text on world canvas
            StartCoroutine(DisplayText());
        }
        //make npc channel
    }

    public override void Deactivate()
    {
        Debug.Log("Mind Control deactivated");
        isActive = false;
        _elementToActivate.Deactivate();
        //stop npc channel
    }

    IEnumerator DisplayText()
    {
        _textBox.text = _textLines[Random.Range(0, _textLines.Count)];
        yield return new WaitForSeconds(_textDisplayTime);
        _textBox.text = "";
    }
}
