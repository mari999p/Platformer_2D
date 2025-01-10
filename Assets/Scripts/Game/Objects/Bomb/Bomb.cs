using System.Collections;
using Platformer.Game.Common;
using Platformer.Game.Enemy.EnemyAttacks;
using UnityEngine;

namespace Platformer.Game.Objects.Bomb
{
    public class Bomb : MonoBehaviour
    {
        #region Variables

        [SerializeField] private Rigidbody2D _rb;
        [SerializeField] private BombAnimation _bombAnimation;
        [SerializeField] private LayerMask _layer;
        [SerializeField] private float _speed = 10f;
        [SerializeField] private float _lifetime = 3f;
        [SerializeField] private int _damage = 2;
        [SerializeField] private float _blastRadius = 5f;
        [SerializeField] private float _explosionForce = 10f;
        [SerializeField] private float _defuseAnimationDuration = 5f;
        private Vector3 _direction;
        private bool _isDefused;

        #endregion

        #region Unity lifecycle

        private void Start()
        {
            InitializeBomb();
            StartCoroutine(DestroyWithLifetimeDelay());
        }

        private void Update()
        {
            transform.position += _direction * (_speed * Time.deltaTime);
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, _blastRadius);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (_isDefused)
            {
                return;
            }

            if (other.TryGetComponent(out EnemyDefuseBomb enemy) && !enemy.isDefusing)
            {
                Explode();
            }

            if (other.TryGetComponent(out IDamageable damageable))
            {
                damageable.ApplyDamage(_damage);
                Explode();
            }
        }

        #endregion

        #region Public methods

        public void Defuse()
        {
            if (_isDefused)
            {
                return;
            }

            _isDefused = true;
            _bombAnimation.TriggerDefuse();
            StartCoroutine(DefuseCoroutine());
            Destroy(gameObject, _defuseAnimationDuration);
        }

        public void DefuseWithFist()
        {
            _isDefused = true;
        }

        public void SetDirection(Vector3 direction)
        {
            _direction = direction;
        }

        public void SetSpeed(float bombSpeed)
        {
            _speed = bombSpeed;
        }

        #endregion

        #region Private methods

        private IEnumerator DefuseCoroutine()
        {
            yield return new WaitForSeconds(_defuseAnimationDuration);
            StopAllCoroutines();
        }

        private IEnumerator DestroyWithLifetimeDelay()
        {
            yield return new WaitForSeconds(_lifetime);
            if (!_isDefused)
            {
                Explode();
            }
        }

        private void Explode()
        {
            _bombAnimation.TriggerExplosion();
            Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, _blastRadius, _layer);
            foreach (Collider2D collider1 in colliders)
            {
                if (collider1.TryGetComponent(out IDamageable hp))
                {
                    hp.ApplyDamage(_damage);
                }

                if (collider1.TryGetComponent(out Rigidbody2D rb))
                {
                    Vector3 forceDirection = collider1.transform.position - transform.position;
                    forceDirection.z = 0;
                    forceDirection.Normalize();
                    rb.AddForce(forceDirection * _explosionForce, ForceMode2D.Impulse);
                }
            }

            Destroy(gameObject);
        }

        private void InitializeBomb()
        {
            _rb.constraints = RigidbodyConstraints2D.FreezeRotation;
            _bombAnimation.TriggerIgnite();
            _rb.velocity = _direction * _speed;
        }

        #endregion
    }
}