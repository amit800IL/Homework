using UnityEngine;
using UnityEngine.Events;

public class PlayerMovement : MonoBehaviour
{
    public UnityEvent OnFailure;

    [Header("Movement")]
    public float moveSpeed = 6f;
    public float movementMultiplayer = 10f;
    [SerializeField] float airMultiplayer = 0.4f;

    [SerializeField] Transform orientation;

    [Header("Sprinting")]
    [SerializeField] float walkSpeed = 4f;
    [SerializeField] float sprintSpeed = 6f;
    [SerializeField] float Acceleration = 10f;


    [Header("jumping")]
    public float jumpForce = 5f;

    [Header("KeyBinds")]
    [SerializeField] KeyCode jumpKey = KeyCode.Space;
    [SerializeField] KeyCode sprintKey = KeyCode.LeftShift;


    private float PlayerHeight = 2f;

    [Header("drag")]

    float groundDrag = 6f;
    float airDrag = 6f;

    float horizontalMovement;
    float verticalMovement;

    [Header("Ground check")]
    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask groundMask;
    [SerializeField] float groundDistance = 0.2f;
    public bool isGrounded;

    [SerializeField] Vector3 moveDirection;
    [SerializeField] Vector3 slopeMoveDirection;

    Rigidbody rb;
    [Header("Force Addition")]

  

    RaycastHit slopeHit;
    private bool OnSlope()
    {
        if (Physics.Raycast(transform.position, Vector3.down, out slopeHit, PlayerHeight / 2 + 8.5f))
        {
            if (slopeHit.normal != Vector3.up)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        return false;
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;




    }

    private void Update()
    {
        

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        myInput();
        controlDrag();
        controlSpeed();

        if (Input.GetKeyDown(jumpKey) && isGrounded)
        {
            jump();
        }

        slopeMoveDirection = Vector3.ProjectOnPlane(moveDirection, slopeHit.normal);
    }

    private void FixedUpdate()
    {
        movePlayer();
    }

    void myInput()
    {
        horizontalMovement = Input.GetAxisRaw("Horizontal");
        verticalMovement = Input.GetAxisRaw("Vertical");

        moveDirection = orientation.forward * verticalMovement + orientation.right * horizontalMovement;

    }

    void jump()
    {
        if (isGrounded)
        {
            rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);
            rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
        }

    }

    void controlSpeed()
    {
        if (Input.GetKey(sprintKey) && isGrounded)
            moveSpeed = Mathf.Lerp(moveSpeed, sprintSpeed, Acceleration * Time.deltaTime);
        else
            moveSpeed = Mathf.Lerp(moveSpeed, walkSpeed, Acceleration * Time.deltaTime);

    }

    void controlDrag()
    {
        if (isGrounded)
        {
            rb.drag = groundDrag;
        }
        else
            rb.drag = airDrag;
    }

    public void movePlayer()
    {
        if (isGrounded && !OnSlope())
            rb.AddForce(moveDirection.normalized * moveSpeed * movementMultiplayer, ForceMode.Force);

        else if (isGrounded && OnSlope())
            rb.AddForce(slopeMoveDirection.normalized * moveSpeed * movementMultiplayer * airMultiplayer, ForceMode.Acceleration);

        else if (!isGrounded)
            rb.AddForce(moveDirection.normalized * moveSpeed * movementMultiplayer * airMultiplayer, ForceMode.Acceleration);


    }
}
