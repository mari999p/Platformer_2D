using UnityEngine;

namespace Platformer.Player
{
    public class PlayerAttack : MonoBehaviour
    {
        [SerializeField] private PlayerAnimation _playerAnimation;

        [SerializeField] private float _attackCooldown;
        private float _nextAttackTime;
        [SerializeField] private PlayerBomb _playerBombPrefab; 
        [SerializeField] private Transform _spawnPointTransform;
       
 

        private void Update()
        {
            if (Input.GetButtonDown("Fire1") && Time.time >= _nextAttackTime)
            {
                PerformAttack();
                _nextAttackTime = Time.time + _attackCooldown;
            }
        }

       

        private void PerformAttack()
        {
            _playerAnimation.TriggerAttack();
            PlayerBomb bomb = Instantiate(_playerBombPrefab, _spawnPointTransform.position, _spawnPointTransform.rotation);
            
        }
    }
}