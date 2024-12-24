using Platformer.Game.Common;
using UnityEngine;

namespace Platformer.Game.Enemy.EnemyAttacks
{
    public class MeleeEnemyAttack : EnemyAttack
    {
        #region Variables

        [Header(nameof(MeleeEnemyAttack))]
        [SerializeField] private Transform _hitMarkerTransform;
        [SerializeField] private LayerMask _hitMask;
        [SerializeField] private float _hitRadius = 1f;
        [SerializeField] private int _damage = 1;
        [SerializeField] private float _knockbackForce = 5f;
        #endregion

        #region Unity lifecycle

        private void OnEnable()
        {
            Animation.OnAttackHit += AttackHitCallback;
        }

        private void OnDisable()
        {
            Animation.OnAttackHit -= AttackHitCallback;
        }

        private void OnDrawGizmosSelected()
        {
            if (_hitMarkerTransform == null)
            {
                return;
            }

            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(_hitMarkerTransform.position, _hitRadius);
        }

        #endregion

        #region Private methods

        private void Attack()
        {
            Collider2D[] colliders = Physics2D.OverlapCircleAll(_hitMarkerTransform.position, _hitRadius, _hitMask);
            foreach (Collider2D col in colliders)
            {
                if (col.TryGetComponent(out IDamageable damageable))
                {
                    damageable.ApplyDamage(_damage);
                    if (col.TryGetComponent(out Rigidbody2D rb))
                    {
                        Vector2 knockbackDirection = (col.transform.position - _hitMarkerTransform.position).normalized;
                        rb.AddForce(knockbackDirection * _knockbackForce, ForceMode2D.Impulse);
                    }
                }
            }
        }

        private void AttackHitCallback()
        {
            Attack();
        }

        #endregion
    }
}