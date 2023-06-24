using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BasePuzzleElement : MonoBehaviour
{
    public bool isActive;
    //[SerializeField] protected animations

    public abstract void Activate();

    public abstract void Deactivate();
}
