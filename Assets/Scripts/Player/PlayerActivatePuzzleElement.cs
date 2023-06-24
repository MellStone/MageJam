using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerActivatePuzzleElement : MonoBehaviour
{
    private ShadowPuzzleElement _shadowElement = null;
    private IcePuzzleElement _iceElement = null;
    private BasePuzzleElement _closestElement = null;
    private float _distanceToClosesElement;
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
                break;
            }
        }
        if(_closestElement != null)
        {
            _distanceToClosesElement = (transform.position - _closestElement.transform.position).magnitude;
            //Debug.Log(_distanceToClosesElement);
        }
        if(Input.GetKeyDown("e") && _distanceToClosesElement <= _interactionDistance)
        {
            if(_closestElement != null)
            {               
                if(!_closestElement.isActive)
                {
                    _closestElement.Activate();
                    if (_closestElement.transform.TryGetComponent(out IcePuzzleElement iceElement) && _iceElement == null)
                    {
                        _iceElement = iceElement;
                    }
                    else if (_iceElement != null && _closestElement is IcePuzzleElement)
                    {
                        _iceElement.Deactivate();
                        _iceElement = iceElement;
                    }
                    else if(_closestElement.transform.TryGetComponent(out ShadowPuzzleElement shadowElement) && _shadowElement == null)
                    {
                        _shadowElement = shadowElement;
                    }
                    else if(_shadowElement != null && _closestElement is ShadowPuzzleElement)
                    {
                        _shadowElement.Deactivate();
                        _shadowElement = shadowElement;
                    }
                }

                else if(_closestElement.isActive)
                {
                    _closestElement.Deactivate();
                    if (_closestElement.transform.TryGetComponent(out IcePuzzleElement iceElement))
                    {                
                        _iceElement = null;
                    }
                    else if (_closestElement.transform.TryGetComponent(out ShadowPuzzleElement shadowElement))
                    {
                        _shadowElement = null;
                    }
                }
            }
            
        }
    }
}
