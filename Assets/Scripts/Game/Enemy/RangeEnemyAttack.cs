using Platformer.Game.Enemy.Base;
using Platformer.Game.Player;
using UnityEngine;

namespace Platformer.Game.Enemy
{
    public class RangeEnemyAttack : EnemyAttack
    {
        #region Variables

        [Header(nameof(RangeEnemyAttack))]
        [SerializeField] private Bomb _bombPrefab;
        [SerializeField] private Transform _spawnPointTransform;
        [SerializeField] private float _attackCooldown = 2f;
        [SerializeField] private float _bombSpeed = 5f;
        private float _rangeNextAttackTime;

        #endregion

        #region Unity lifecycle

        protected override void Update()
        {
            base.Update();
            if (_needAttack && Time.time >= _rangeNextAttackTime)
            {
                PerformAttack();
                _rangeNextAttackTime = Time.time + _attackCooldown;
            }
        }

        #endregion

        #region Private methods

        private void PerformAttack()
        {
            OnPerformAttack();
            Bomb bomb = Instantiate(_bombPrefab, _spawnPointTransform.position, _spawnPointTransform.rotation);
            Vector3 direction = (Target.position - _spawnPointTransform.position).normalized;
            bomb.SetDirection(direction);
            bomb.SetSpeed(_bombSpeed);
            RotateTowardsTarget();
        }

        private void RotateTowardsTarget()
        {
            if (Target == null)
            {
                return;
            }

            float directionToTarget = Target.position.x - transform.position.x;
            float targetRotationZ = directionToTarget > 0 ? 0f : 130f;
            _spawnPointTransform.rotation = Quaternion.Euler(0f, 0f, targetRotationZ);
            transform.localScale = new Vector3(Mathf.Sign(directionToTarget) * -Mathf.Abs(transform.localScale.x),
                transform.localScale.y, transform.localScale.z);
        }

        #endregion
    }
}