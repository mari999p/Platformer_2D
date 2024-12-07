using Platformer.Service.Input;
using UnityEngine;
using Zenject;

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
        private IInputService _inputService;
        #endregion

        #region Unity lifecycle
        [Inject]
        public void Construct(IInputService inputService)
        {
            _inputService = inputService;
        }
        private void Start()
        {
            _inputService.OnAttacked += PerformAttack;
        }

        private void OnDestroy()
        {
            _inputService.OnAttacked -= PerformAttack;
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