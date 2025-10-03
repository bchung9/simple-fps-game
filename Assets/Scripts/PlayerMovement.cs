using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController controller;

    public float gravity = -9.81f * 2;
    public float jumpHeight = 3f;
    public float speed = 8f;
    public float sprintSpeed = 14f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;

    bool isGrounded;
    bool isMoving;

    private Vector3 lastPosition = new Vector3(0f, 0f, 0f);

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        // Check if player is on ground
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        // Resetting to default velocity
        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        // Receiving inputs
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        // Creating moving vector
        Vector3 move = transform.right * x + transform.forward * z;

        // Player movement (Sprint and Walking)
        if (Input.GetKey(KeyCode.LeftShift))
        {
            controller.Move(move * sprintSpeed * Time.deltaTime);
        }
        else
        {
            controller.Move(move * speed * Time.deltaTime);
        }

        // Check if player can jump
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            // Jumping
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        // Falling
        velocity.y += gravity * Time.deltaTime;

        // Executing jump
        controller.Move(velocity * Time.deltaTime);

        if (lastPosition != gameObject.transform.position && isGrounded == true)
        {
            isMoving = true;
            // later
        }
        else
        {
            isMoving = false;
            // later
        }

        lastPosition = gameObject.transform.position;
    }
}
