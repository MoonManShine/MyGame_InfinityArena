using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    [SerializeField] private float speed = 5f;
    [SerializeField] private float jumpForce = 2f;
    [SerializeField] private float yVelocity = 0f;
    public float gravity = -9.81f;
    private CharacterController _controller;

    void Start()
    {
        _controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMove();
    }

    void PlayerMove()
    {
        float moveX = Input.GetAxis("Horizontal"); // A & D
        float moveZ = Input.GetAxis("Vertical"); // W & S

        Vector3 move = transform.right * moveX + transform.forward * moveZ;

        //jump
        if (_controller.isGrounded && yVelocity < 0)
            yVelocity = -2f; //falling

        if (Input.GetKeyDown(KeyCode.Space) && _controller.isGrounded)
            yVelocity = Mathf.Sqrt(jumpForce * -2f * gravity);

        //gravity
        yVelocity += gravity * Time.deltaTime;
        move.y = yVelocity;
        
        _controller.Move(move * speed * Time.deltaTime);
    }
}
