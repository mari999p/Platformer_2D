using System;
using JetBrains.Annotations;
using Platformer.Game.Common;
using Platformer.Game.Player.Animation;
using Platformer.UI;
using UnityEngine;

namespace Platformer.Game.Player
{
    public class PlayerDeath : MonoBehaviour
    {
        #region Variables

        [SerializeField] private UnitHp _hp;
        [SerializeField] private Collider2D _collider;
        [SerializeField] private Rigidbody2D _rb;
        [SerializeField] private PlayerMovement _movement;
        [SerializeField] private PlayerAttack _attack;
        [SerializeField] private PlayerAnimation _animation;
        [SerializeField] private GameOverScreen _gameOverScreen;
        #endregion

        #region Events

        public event Action OnOccurred;

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

        #region Public methods

        public void Heal(int healAmount)
        {
            if (IsDead)
            {
                return;
            }

            _hp.Change(healAmount);
        }

        #endregion

        #region Private methods

        public void Die()
        {
            IsDead = true;
            _collider.enabled = false;
            _animation.TriggerDeath();
            _movement.Deactivate();
            _attack.Deactivate();
            _rb.velocity = Vector2.zero;
            _rb.bodyType = RigidbodyType2D.Kinematic;
            OnOccurred?.Invoke();
            _gameOverScreen.ShowGameOver();
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