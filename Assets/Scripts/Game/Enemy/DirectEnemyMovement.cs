using Platformer.Game.Enemy.Base;
using UnityEngine;

namespace Platformer.Game.Enemy
{
    public class DirectEnemyMovement : EnemyMovement
    {
        #region Variables

        [SerializeField] private Rigidbody2D _rb;
        [SerializeField] private float _speed = 3f;
        [SerializeField] private SpriteRenderer _spriteRenderer;
        private Transform _target;

        #endregion

        #region Unity lifecycle

        private void Update()
        {
            if (_target == null)
            {
                return;
            }

            Rotate();
            Move();
        }

        private void OnDisable()
        {
            ResetVelocity();
        }

        #endregion

        #region Public methods

        public override void SetTarget(Transform target)
        {
            _target = target;

            if (target == null)
            {
                ResetVelocity();
            }
        }

        #endregion

        #region Private methods

        private void Move()
        {
            Vector2 direction = (_target.position - transform.position).normalized;
            Vector2 velocity = Vector2.right * (direction.x * _speed);
            _rb.velocity = velocity;
            Animation.SetSpeed(_speed);
        }

        private void ResetVelocity()
        {
            _rb.velocity = Vector2.zero;
            Animation.SetSpeed(0);
        }

        private void Rotate()
        {
            _spriteRenderer.flipX = _target.position.x > transform.position.x;
            Vector3 rotation = transform.eulerAngles;
            rotation.z = 0;
            transform.eulerAngles = rotation;
        }

        #endregion
    }
}