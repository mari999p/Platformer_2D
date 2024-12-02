using Platformer.Game.Common;
using UnityEngine;

namespace Platformer.Game.Enemy.Base
{
    public sealed class EnemyAttackAgro : EnemyBehaviour
    {
        #region Variables

        [SerializeField] private TriggerObserver _triggerObserver;
        [SerializeField] private EnemyMovement _movement;
        [SerializeField] private EnemyAttack _attack;

        #endregion

        #region Unity lifecycle

        private void OnEnable()
        {
            _triggerObserver.OnEntered += TriggerEnteredCallback;
            _triggerObserver.OnExited += TriggerExitedCallback;
        }

        private void OnDisable()
        {
            _triggerObserver.OnEntered -= TriggerEnteredCallback;
            _triggerObserver.OnExited -= TriggerExitedCallback;
        }

        #endregion

        #region Private methods

        private void TriggerEnteredCallback(Collider2D col)
        {
            _movement.Deactivate();
            _attack.StartAttack(col.transform);
        }

        private void TriggerExitedCallback(Collider2D col)
        {
            _attack.StopAttack();
            _movement.Activate();
        }

        #endregion
    }
}