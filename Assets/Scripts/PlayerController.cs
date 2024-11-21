using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CharacterController))] 
[HideInInspector]
public class PlayerController : MonoBehaviour {
    CharacterController _characterController;
    private Camera _playerCamera;
    public float walkingSpeed = 7.5f;
    public float runningSpeed = 11.5f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;
    public float lookSpeed = 2.0f;
    public float lookXLimit = 45.0f;
    private Vector3 _moveDirection = Vector3.zero;
    private float _rotationX = 0;
    public bool canMove = true; 
    private Vector3 _forward;
    private Vector3 _right;
    private void Start(){
        _playerCamera = Camera.main;
        _characterController = GetComponent<CharacterController>();
        Update();
    }
    private void Update(){
        _forward = transform.TransformDirection(Vector3.forward);
        _right = transform.TransformDirection(Vector3.right);
        var isRunning = Input.GetKey(KeyCode.LeftShift);
        var curSpeedX = canMove ? (isRunning ? runningSpeed : walkingSpeed) * Input.GetAxis("Vertical") : 0;
        var curSpeedY = canMove ? (isRunning ? runningSpeed : walkingSpeed) * Input.GetAxis("Horizontal") : 0;
        var movementDirectionY = _moveDirection.y;
        _moveDirection = (_forward * curSpeedX) + (_right * curSpeedY);

        if (Input.GetButton("Jump") && canMove && _characterController.isGrounded) {
            _moveDirection.y = jumpSpeed;
        }
        else {
            _moveDirection.y = movementDirectionY;
        }

        if (!_characterController.isGrounded) {
            _moveDirection.y -= gravity * Time.deltaTime;
        }
        _characterController.Move(_moveDirection * Time.deltaTime);
        if (!canMove) return;
        _rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
        _rotationX = Mathf.Clamp(_rotationX, -lookXLimit, lookXLimit);
        _playerCamera.transform.localRotation = Quaternion.Euler(_rotationX, 0, 0);
        transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);
    }
}


