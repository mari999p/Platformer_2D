using Platformer.Game.Common;
using UnityEngine;

namespace Platformer.Game.Enemy.InteractionZone
{
    public sealed class EnemyMovementAgro : EnemyBehaviour
    {
        #region Variables

        [SerializeField] private TriggerObserver _moveObserver;
        [SerializeField] private EnemyIdle _idle;
        [SerializeField] private EnemyMovement _movement;

        [SerializeField] private Vector2 _minBounds;
        [SerializeField] private Vector2 _maxBounds;
        private TriggerObserver _stopChasingObserver;

        #endregion

        #region Unity lifecycle

        private void Update()
        {
            Vector3 clampedPosition = transform.position;
            clampedPosition.x = Mathf.Clamp(clampedPosition.x, _minBounds.x, _maxBounds.x);
            clampedPosition.y = Mathf.Clamp(clampedPosition.y, _minBounds.y, _maxBounds.y);
            transform.position = clampedPosition;
        }

        private void OnEnable()
        {
            _moveObserver.OnEntered += TriggerEnteredCallback;

            if (_stopChasingObserver != null)
            {
                _stopChasingObserver.OnExited += TriggerExitedCallback;
            }
            else
            {
                _moveObserver.OnExited += TriggerExitedCallback;
            }
        }

        private void OnDisable()
        {
            _moveObserver.OnEntered -= TriggerEnteredCallback;

            if (_stopChasingObserver != null)
            {
                _stopChasingObserver.OnExited -= TriggerExitedCallback;
            }
            else
            {
                _moveObserver.OnExited -= TriggerExitedCallback;
            }
        }

        #endregion

        #region Private methods

        private void TriggerEnteredCallback(Collider2D col)
        {
            if (!col.CompareTag(Tag.Player))
            {
                return;
            }

            _idle.Deactivate();
            _movement.Activate();
            _movement.SetTarget(col.transform);
        }

        private void TriggerExitedCallback(Collider2D col)
        {
            if (!col.CompareTag(Tag.Player))
            {
                return;
            }

            _movement.Deactivate();
            _idle.Activate();
        }

        #endregion
    }
}