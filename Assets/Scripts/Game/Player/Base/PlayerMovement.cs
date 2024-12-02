using UnityEngine;

namespace Platformer.Game.Player.Base
{
    public class PlayerMovement : PlayerBehaviour
    {
        #region Variables

        [Header("Components")]
        [SerializeField] private PlayerAnimation _animation;

        [Header("Settings")]
        [SerializeField] private Rigidbody2D _rb;
        [SerializeField] private float _speed = 10;
        [SerializeField] private SpriteRenderer _spriteRenderer;
        [SerializeField] private float _jumpForce = 5;
        [Header("Ground Check")]
        [SerializeField] private LayerMask _groundLayer;
        [SerializeField] private Transform _groundCheck;
        [SerializeField] private float _groundCheckRadius = 0.1f;
        private bool _isGrounded;

        #endregion

        #region Unity lifecycle

        private void Update()
        {
            Move();
            Rotate();
            Jump();
        }

        private void FixedUpdate()
        {
            CheckGround();
        }

        #endregion

        #region Private methods

        private void CheckGround()
        {
            _isGrounded = Physics2D.OverlapCircle(_groundCheck.position, _groundCheckRadius, _groundLayer);
        }

        private void Jump()
        {
            if (Input.GetKeyDown(KeyCode.Space) && _isGrounded)
            {
                _rb.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
                _animation.TriggerJump();
            }
        }

        private void Move()
        {
            float horizontal = Input.GetAxis("Horizontal");
            Vector2 direction = new(horizontal, 0);
            float currentSpeed = _speed;

            Vector2 velocity = direction.normalized * currentSpeed;
            velocity.y = _rb.velocity.y;
            _rb.velocity = velocity;

            _animation.SetMovement(direction.magnitude);
        }

        private void Rotate()
        {
            if (Input.GetAxis("Horizontal") != 0)
            {
                _spriteRenderer.flipX = Input.GetAxis("Horizontal") < 0;
            }

            Vector3 rotation = transform.eulerAngles;
            rotation.z = 0;
            transform.eulerAngles = rotation;
        }

        #endregion
    }
}