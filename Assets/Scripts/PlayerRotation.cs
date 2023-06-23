using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    PlayerMovement movement;
    Transform model;

    private void Awake()
    {
        model = transform.GetChild(0);
        movement = GetComponent<PlayerMovement>();
    }

    void Update()
    {
        if (movement.movement.magnitude > 0.1f)
        {
            Quaternion targetRotation = Quaternion.LookRotation(movement.movement);
            model.rotation = Quaternion.Lerp(model.rotation, targetRotation, Time.deltaTime * movement.rotateSpeed);
        }
    }
}
