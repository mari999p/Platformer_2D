using Platformer.Game.Common;
using UnityEngine;

namespace Platformer.Game.Enemy.Base
{
    public sealed class EnemyMovementAgro : EnemyBehaviour
    {
        #region Variables

        [SerializeField] private TriggerObserver _moveObserver;
        [SerializeField] private TriggerObserver _stopChasingObserver;
        [SerializeField] private EnemyIdle _idle;
        [SerializeField] private EnemyMovement _movement;

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

        #region Private methods

        private void TriggerEnteredCallback(Collider2D col)
        {
            if (!col.CompareTag("Player"))
            {
                return;
            }

            _idle.Deactivate();
            _movement.Activate();
            _movement.SetTarget(col.transform);
        }

        private void TriggerExitedCallback(Collider2D col)
        {
            if (!col.CompareTag("Player"))
            {
                return;
            }

            _movement.Deactivate();
            _idle.Activate();
        }

        #endregion
    }
}