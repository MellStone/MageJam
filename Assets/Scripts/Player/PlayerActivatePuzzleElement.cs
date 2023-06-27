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
    private Animator animator;
    Collider[] colliders = new Collider[25];
    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
    }
    private void Update()
    {
        Physics.OverlapSphereNonAlloc(transform.position, _interactionDistance, colliders, _puzzleElementLayer);
        foreach(var hit in colliders)
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
            if (_distanceToClosesElement <= _interactionDistance)
            {
                _closestElement.StartInteractionParticles();
            }
            else if(_distanceToClosesElement > _interactionDistance)
            {
                _closestElement.StopInteractionParticles();
            }
        }

        
        if(Input.GetKeyDown("e") && _distanceToClosesElement <= _interactionDistance)
        {
            if(_closestElement != null)
            {               
                if(!_closestElement.isActive)
                {
                    _closestElement.Activate();
                    animator.SetBool("isSpellCast", true);

                    if (_iceElement == null && _closestElement is IcePuzzleElement)
                    {
                        _iceElement = (IcePuzzleElement)_closestElement;
                    }
                    else if (_iceElement != null && _closestElement is IcePuzzleElement)
                    {
                        _iceElement.Deactivate();
                        _iceElement = (IcePuzzleElement)_closestElement;
                    }
                    else if(_shadowElement == null && _closestElement is ShadowPuzzleElement)
                    {
                        _shadowElement = (ShadowPuzzleElement)_closestElement;
                    }
                    else if(_shadowElement != null && _closestElement is ShadowPuzzleElement)
                    {
                        _shadowElement.Deactivate();
                        _shadowElement = (ShadowPuzzleElement)_closestElement;
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
        if (Input.GetKeyUp("e"))
        {
            animator.SetBool("isSpellCast", false);
        }
    }
}
