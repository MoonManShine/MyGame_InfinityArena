using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    [SerializeField] private float speed = 5f;
    private CharacterController _controller;

    void Start()
    {
        _controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveX = Input.GetAxis("Horizontal"); // A & D
        float moveZ = Input.GetAxis("Vertical"); // W & S

        Vector3 move = transform.right * moveX + transform.forward * moveZ;
        _controller.Move(move * speed * Time.deltaTime);
    }
}
