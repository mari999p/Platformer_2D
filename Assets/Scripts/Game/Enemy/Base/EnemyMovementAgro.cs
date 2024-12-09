using Platformer.Game.Common;
using UnityEngine;

namespace Platformer.Game.Enemy.Base
{
    public sealed class EnemyMovementAgro : EnemyBehaviour
    {
        #region Variables

        [SerializeField] private TriggerObserver _moveObserver;
        [SerializeField] private EnemyIdle _idle;
        [SerializeField] private EnemyMovement _movement;
        private TriggerObserver _stopChasingObserver;

        #endregion

        #region Unity lifecycle

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

        #region Public methods

        public void ResumeMovement()
        {
            _movement.Activate();
        }

        public void StopMovement()
        {
            _movement.Deactivate();
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