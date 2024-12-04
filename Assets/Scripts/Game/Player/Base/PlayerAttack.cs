using UnityEngine;

namespace Platformer.Game.Player.Base
{
    public class PlayerAttack : PlayerBehaviour
    {
        #region Variables

        [SerializeField] private PlayerAnimation _playerAnimation;
        [SerializeField] private float _attackCooldown;
        [SerializeField] private Bomb _playerBombPrefab;
        [SerializeField] private Transform _spawnPointTransform;
        private float _nextAttackTime;

        #endregion

        #region Unity lifecycle

        private void Update()
        {
            if (Input.GetButtonDown("Fire1") && Time.time >= _nextAttackTime)
            {
                PerformAttack();
                _nextAttackTime = Time.time + _attackCooldown;
            }
        }

        #endregion

        #region Private methods

        private void PerformAttack()
        {
            _playerAnimation.TriggerAttack();
            Instantiate(_playerBombPrefab, _spawnPointTransform.position, _spawnPointTransform.rotation);
        }

        #endregion
    }
}