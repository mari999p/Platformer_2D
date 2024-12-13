using Platformer.Service.Input;
using UnityEngine;
using Zenject;

namespace Platformer.Game.Player.Base
{
    public class PlayerMovement : PlayerBehaviour
    {
        #region Variables

        [Header("Components")]
        [SerializeField] private PlayerAnimation _animation;
        [SerializeField] private GameEffectsAnimation _gameEffectsAnimation;

        [Header("Settings")]
        [SerializeField] private Rigidbody2D _rb;
        [SerializeField] private float _speed = 10;
        [SerializeField] private SpriteRenderer _spriteRenderer;
        [SerializeField] private float _jumpForce = 5;
        [Header("Ground Check")]
        [SerializeField] private LayerMask _groundLayer;
        [SerializeField] private Transform _groundCheck;
        [SerializeField] private float _groundCheckRadius = 0.1f;
        private IInputService _inputService;
        private bool _isGrounded;
        private bool _wasGrounded;

        #endregion

        #region Setup/Teardown

        [Inject]
        public void Construct(IInputService inputService)
        {
            _inputService = inputService;
        }

        #endregion

        #region Unity lifecycle

        private void Start()
        {
            _inputService.OnJump += Jump;
        }

        private void Update()
        {
            Move();
            Rotate();
        }

        private void FixedUpdate()
        {
            CheckGround();
        }

        private void OnDestroy()
        {
            _inputService.OnJump -= Jump;
        }

        #endregion

        #region Private methods

        private void CheckGround()
        {
            _wasGrounded = _isGrounded;
            _isGrounded = Physics2D.OverlapCircle(_groundCheck.position, _groundCheckRadius, _groundLayer);
            if (!_wasGrounded && _isGrounded)
            {
                _gameEffectsAnimation.TriggerJumpParticles();
            }
        }

        private void Jump()
        {
            if (_isGrounded)
            {
                _rb.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
                _animation.TriggerJump();
            }
        }

        private void Move()
        {
            Vector2 velocity = _inputService.MoveDirection.normalized * _speed;
            velocity.y = _rb.velocity.y;
            _rb.velocity = velocity;
            _animation.SetMovement(velocity.magnitude);
        }

        private void Rotate()
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
            if (_inputService.MoveDirection.x != 0)
            {
                _spriteRenderer.flipX = _inputService.MoveDirection.x < 0;
            }
        }

        #endregion
    }
}