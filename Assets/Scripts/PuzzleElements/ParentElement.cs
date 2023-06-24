using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentElement : KeyElement
{
    [SerializeField] private List<BasePuzzleElement> _puzzleElementsToSpawn = new List<BasePuzzleElement>();

    private void Awake()
    {
        isActive = false;
    }

    private void Update()
    {
        int counter = 0;
        foreach (BasePuzzleElement element in _requiredPuzzleElements)
        {
            if (element.isActive)
            {
                counter++;
            }
        }

        if (counter == _requiredPuzzleElements.Count && !isActive)
        {
            Activate();
        }
        else if(counter != _requiredPuzzleElements.Count && isActive)
        {
            Deactivate();
        }
    }

    public new void Activate()
    {
        isActive = true;
        foreach(BasePuzzleElement element in _puzzleElementsToSpawn) 
        {
            element.gameObject.SetActive(true);
        }
    }

    public void Deactivate()
    {
        isActive = false;
        foreach(BasePuzzleElement spawnedElement in _puzzleElementsToSpawn)
        {
            spawnedElement.Deactivate();
            spawnedElement.gameObject.SetActive(false);
        }
    }
}
