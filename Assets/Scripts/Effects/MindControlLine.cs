using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MindControlLine : MonoBehaviour
{
    [SerializeField] private GameObject go1;
    [SerializeField] private GameObject go2;
    private S_MindControl _mindControl;
    private LineRenderer _line;

    private void Start()
    {
        _line = GetComponent<LineRenderer>();
        _mindControl = GetComponent<S_MindControl>();
    }
    void Update()
    {
        if(_mindControl.isActive)
        {
            _line.enabled = true;
            List<Vector3> pos = new List<Vector3>();
            pos.Add(go1.transform.position);
            pos.Add(go2.transform.position);
            _line.startWidth = 0.1f;
            _line.endWidth = 0.1f;
            _line.SetPositions(pos.ToArray());
            _line.useWorldSpace = true;
        }    
        else
        {
            _line.enabled = false;
        }
    }
}
