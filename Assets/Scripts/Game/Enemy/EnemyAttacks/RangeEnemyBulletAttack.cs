using Platformer.Game.Objects;
using UnityEngine;

namespace Platformer.Game.Enemy.EnemyAttacks
{
    public class RangeEnemyBulletAttack : EnemyAttack
    {
        #region Variables

        [Header(nameof(RangeEnemyAttack))]
        [SerializeField] private Bullet _bulletPrefab;
        [SerializeField] private Transform _spawnPointTransform;

        #endregion

        #region Unity lifecycle

        protected override void Update()
        {
            base.Update();
            Rotate();
        }

        #endregion

        #region Protected methods

        protected override void OnPerformAttack()
        {
            base.OnPerformAttack();
            Bullet newBullet = Instantiate(_bulletPrefab, _spawnPointTransform.position, _spawnPointTransform.rotation);
            newBullet.SetDirection(_spawnPointTransform.right);
        }

        #endregion

        #region Private methods

        private void Rotate()
        {
            if (Target == null)
            {
                return;
            }

            float directionToTarget = Target.position.x - transform.position.x;
            float targetRotationZ = directionToTarget > 0 ? 0f : 180f;
            _spawnPointTransform.rotation = Quaternion.Euler(0f, 0f, targetRotationZ);
            transform.localScale = new Vector3(Mathf.Sign(directionToTarget) * -Mathf.Abs(transform.localScale.x),
                transform.localScale.y, transform.localScale.z);
        }

        #endregion
    }
}