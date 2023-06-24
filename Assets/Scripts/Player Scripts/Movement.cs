using UnityEngine;

namespace Player_Scripts
{
    public class Movement : MonoBehaviour
    {
        private CharacterController _controller;
        private Camera _cam;

        [SerializeField] float rotationSmoothTime;
        private float _currentAngle;
        private float _currentAngleVelocity;

        [SerializeField] private float speed;

        [Header("Gravity")]
        [SerializeField] float gravity = 9.8f;
        [SerializeField] float gravityMultiplier = 2;
        [SerializeField] float groundedGravity = -0.5f;
        [SerializeField] float jumpHeight = 3f;

        private float velocityY;

        private void Awake()
        {
            _controller = GetComponent<CharacterController>();
            _cam = Camera.main;
        }

        void Update()
        {
            HandleMovement();
            HandleGravityAndJump();
        }

        private void HandleMovement()
        {
            Vector3 movement = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized;

            if (movement.magnitude >= 0.1f)
            {
                float targetAngle = Mathf.Atan2(movement.x, movement.z) * Mathf.Rad2Deg + _cam.transform.eulerAngles.y;
                _currentAngle = Mathf.SmoothDampAngle(_currentAngle, targetAngle, ref _currentAngleVelocity, rotationSmoothTime);
                transform.rotation = Quaternion.Euler(0, _currentAngle, 0);
                Vector3 rotatedMovement = Quaternion.Euler(0, targetAngle, 0) * Vector3.forward;
                _controller.Move(rotatedMovement * (speed * Time.deltaTime));
            }
        }

        private void HandleGravityAndJump()
        {
            if (_controller.isGrounded && velocityY < 0f)
                velocityY = groundedGravity;

            if (_controller.isGrounded && Input.GetKeyDown(KeyCode.Space))
            {
                velocityY = Mathf.Sqrt(jumpHeight * 2f * gravity);
            }

            velocityY -= gravity * gravityMultiplier * Time.deltaTime;
            _controller.Move(Vector3.up * (velocityY * Time.deltaTime));
        }
    }
} //Class