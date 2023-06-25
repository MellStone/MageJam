using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("movement")]
    public float moveSpeed;
    public float GroundDrag;

    float horizontalInput;
    float verticalInput;

    public Vector3 moveDirection;
    private Rigidbody rb;
    private Animator animator;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        MyInput();

        SpeedControl();

        rb.drag = GroundDrag;
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
    }

    private void MovePlayer()
    {
        // calculate movement direction
        moveDirection = new Vector3(horizontalInput, 0, verticalInput);
        Animation();
        rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);
    }

    private void SpeedControl()
    {
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
        //limit of velocity  if needed
        if (flatVel.magnitude > moveSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * moveSpeed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);

        }
    }
    private void Animation()
    {
        if (moveDirection != Vector3.zero)
        {
            animator.SetBool("isWalking", true);
        }
        else animator.SetBool("isWalking", false);
    }
}