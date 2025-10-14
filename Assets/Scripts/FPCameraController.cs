using UnityEngine;

public class FPCameraController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    [SerializeField] private float _sensivity;
    [SerializeField] private Transform _player;
    [SerializeField] private float _verticalLover;
    [SerializeField] private float _verticalUpper;
    private float _currentVerticalAngle;

    public bool canLook = true;

    void Start()
    {
        LockCursor();
    }

    // Update is called once per frame
    void Update()
    {
        if (!canLook) return;
        var vertical = -Input.GetAxis("Mouse Y") * _sensivity * Time.deltaTime;
        var horizontal = Input.GetAxis("Mouse X") * _sensivity * Time.deltaTime;

        _currentVerticalAngle = Mathf.Clamp(_currentVerticalAngle + vertical, _verticalUpper, _verticalLover);
        transform.localRotation = Quaternion.Euler(_currentVerticalAngle, 0, 0);

        _player.Rotate(0, horizontal, 0);
    }

    public void LockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void UnlockCursor()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
