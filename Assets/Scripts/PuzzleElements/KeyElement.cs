using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyElement : MonoBehaviour
{
    [HideInInspector] public bool isActive;
    [SerializeField] protected List<BasePuzzleElement> _requiredPuzzleElements = new List<BasePuzzleElement>();

    private void Awake()
    {
        isActive = false;
    }

    private void Update()
    {
        int counter = 0;
        foreach(BasePuzzleElement element in _requiredPuzzleElements) 
        {
            if(element.isActive)
            {
                counter++;
            }
        }

        if(counter == _requiredPuzzleElements.Count && !isActive)
        {
            Activate();
        }
    }

    public void Activate()
    {
        isActive = true;
    }
}
