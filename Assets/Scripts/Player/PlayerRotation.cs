using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    PlayerMovement movement;
    Transform model;
    [SerializeField] private float rotateSpeed;

    private void Awake()
    {
        model = transform.GetChild(0);
        movement = GetComponent<PlayerMovement>();
    }

    void Update()
    {
        if (movement.moveDirection.magnitude > 0.1f)
        {
            Quaternion targetRotation = Quaternion.LookRotation(movement.moveDirection);
            model.rotation = Quaternion.Lerp(model.rotation, targetRotation, Time.deltaTime * rotateSpeed);
        }
    }
}
