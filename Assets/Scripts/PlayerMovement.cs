using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float movementsSpeed = 5f;
    [SerializeField] public float rotateSpeed = 8f;

    float horizontal;
    float vertical;
    public Vector3 movement;
    Rigidbody rb;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        PlayerInput();
        rb.AddForce(movement);
    }
    private void PlayerInput()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        movement = new Vector3(horizontal, 0, vertical);

    }
}