using Platformer.Game.Common;
using Platformer.Game.Enemy.Base;
using UnityEngine;

namespace Platformer.Game.Enemy
{
    public class MeleeEnemyAttack: EnemyAttack
    {
        [Header(nameof(MeleeEnemyAttack))]
        [SerializeField] private Transform _hitMarkerTransform;
        [SerializeField] private float _hitRadius = 1f;
        [SerializeField] private LayerMask _hitMask;
        [SerializeField] private int _damage = 1;
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
        private void Attack()
        {
            Collider2D[] colliders = Physics2D.OverlapCircleAll(_hitMarkerTransform.position, _hitRadius, _hitMask);
            foreach (Collider2D col in colliders)
            {
                if (col.TryGetComponent(out IDamageable damageable))
                {
                    damageable.ApplyDamage(_damage);
                }
            }
        }

        private void AttackHitCallback()
        {
            Attack();
        }
    }
}