using Platformer.Game.Objects.Bomb;
using Platformer.Game.Player.Animation;
using Platformer.Service.Input;
using UnityEngine;
using Zenject;

namespace Platformer.Game.Player
{
    public class PlayerAttack : MonoBehaviour
    {
        #region Variables

        [SerializeField] private PlayerAnimation _playerAnimation;
        [SerializeField] private Bomb _playerBombPrefab;
        [SerializeField] private Transform _spawnPointTransform;
        [SerializeField] private float _attackCooldown;
        private IInputService _inputService;
        private float _nextAttackTime;

        #endregion

        #region Setup/Teardown

        [Inject]
        public void Construct(IInputService inputService)
        {
            _inputService = inputService;
        }

        #endregion

        #region Unity lifecycle

        private void Start()
        {
            _inputService.OnAttacked += PerformAttack;
        }

        private void OnDestroy()
        {
            _inputService.OnAttacked -= PerformAttack;
        }

        #endregion

        #region Public methods

        public void Deactivate()
        {
            enabled = false;
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