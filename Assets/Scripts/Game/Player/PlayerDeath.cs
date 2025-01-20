using System;
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
        private int _previousHp;

        #endregion

        #region Events

        public event Action OnOccurred;

        #endregion

        #region Properties

        public bool IsDead { get; private set; }

        #endregion

        #region Unity lifecycle

        private void Awake()
        {
            _previousHp = int.MaxValue;
        }

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

        private void HpChangedCallback(int hp)
        {
            if (hp < _previousHp)
            {
                _animation.TriggerHit();
            }
            else if (hp > _previousHp) { }

            _previousHp = hp;
            if (hp <= 0 && !IsDead)
            {
                Die();
            }
        }

        #endregion
    }
}