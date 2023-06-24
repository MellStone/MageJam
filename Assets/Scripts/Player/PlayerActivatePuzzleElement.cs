using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActivatePuzzleElement : MonoBehaviour
{
    private ShadowPuzzleElement _shadowElement = null;
    private IcePuzzleElement _iceElement = null;
    private BasePuzzleElement _closestElement = null;
    [SerializeField] private float _interactionDistance;
    [SerializeField] private LayerMask _puzzleElementLayer;

    private void Update()
    {
        Collider[] hitElements = Physics.OverlapSphere(transform.position, _interactionDistance, _puzzleElementLayer);
        foreach(var hit in hitElements)
        {
            if(hit.transform.TryGetComponent(out BasePuzzleElement puzzleElement))
            {
                _closestElement = puzzleElement; 
            }
        }
        if(Input.GetKey("Interact"))
        {
            if(_closestElement != null)
            {
                _closestElement.Activate();
                if(_closestElement.transform.TryGetComponent(out IcePuzzleElement iceElement))
                {
                    if(_iceElement == null)
                    {
                        _iceElement = iceElement;
                        //_iceElement.Activate();
                    }
                    else
                    {
                        _iceElement.Deactivate();
                        _iceElement = iceElement;
                        //_iceElement.Activate();
                    }
                    
                }
                if (_closestElement.transform.TryGetComponent(out ShadowPuzzleElement shadowElement))
                {
                    if (_shadowElement == null)
                    {
                        _shadowElement = shadowElement;
                        //_shadowElement.Activate();
                    }
                    else
                    {
                        _shadowElement.Deactivate();
                        _shadowElement = shadowElement;
                        //_shadowElement.Activate();
                    }
                }

            }
            
        }
    }
}
