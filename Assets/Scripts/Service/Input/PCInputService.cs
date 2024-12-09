using System;
using UnityEngine;

namespace Platformer.Service.Input
{
    public class PCInputService : MonoBehaviour, IInputService
    {
        #region Variables

        private readonly float _attackCooldown = 0.5f;
        private float _nextAttackTime;

        #endregion

        #region Events

        public event Action OnAttacked;
        public event Action OnJump;

        #endregion

        #region Properties

        public Vector2 MoveDirection => new(UnityEngine.Input.GetAxis("Horizontal"), 0);

        #endregion

        #region Unity lifecycle

        private void Update()
        {
            HandleInput();
        }

        #endregion

        #region IInputService

        public void Initialize(Camera mainCamera, Transform playerTransform) { }

        public void Dispose()
        {
            OnAttacked = null;
            OnJump = null;
        }

        #endregion

        #region Private methods

        private void HandleInput()
        {
            if (UnityEngine.Input.GetButtonDown("Fire1") && Time.time >= _nextAttackTime)
            {
                OnAttacked?.Invoke();
                _nextAttackTime = Time.time + _attackCooldown;
            }

            if (UnityEngine.Input.GetKeyDown(KeyCode.Space))
            {
                OnJump?.Invoke();
            }
        }

        #endregion
    }
}