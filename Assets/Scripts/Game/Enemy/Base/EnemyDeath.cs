using System;
using Platformer.Game.Common;
using UnityEngine;

namespace Platformer.Game.Enemy.Base
{
    public class EnemyDeath : EnemyBehaviour
    {
        #region Variables

        [SerializeField] private UnitHp _hp;
        [SerializeField] private Rigidbody2D _rb;
        [SerializeField] private Collider2D _collider;
        [SerializeField] private EnemyMovement _movement;
        [SerializeField] private EnemyAttack _attack;
        [SerializeField] private EnemyIdle _idle;
        [SerializeField] private EnemyMovementAgro _movementAgro;
        [SerializeField] private EnemyAttackAgro _attackAgro;
        [SerializeField] private EnemyAnimation _animation;

        #endregion

        #region Events

        public event Action OnHappened;

        #endregion

        #region Properties

        public bool IsDead { get; private set; }

        #endregion

        #region Unity lifecycle

        private void OnEnable()
        {
            _hp.OnChanged += HpChangedCallback;
        }

        private void OnDisable()
        {
            _hp.OnChanged -= HpChangedCallback;
        }

        #endregion

        #region Private methods

        private void Die()
        {
            IsDead = true;
            _collider.enabled = false;
            _attack.Deactivate();
            _idle.Deactivate();
            _attackAgro.Deactivate();
            _movement.Deactivate();
            _movementAgro.Deactivate();
            _animation.TriggerDeath();
            _rb.velocity = Vector2.zero;
            _rb.bodyType = RigidbodyType2D.Kinematic;
            OnHappened?.Invoke();
        }

        private void HpChangedCallback(int hp)
        {
            if (hp > 0 || IsDead)
            {
                _animation.TriggerHit();
                return;
            }

            Die();
        }

        #endregion
    }
}