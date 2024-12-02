using System.Collections;
using Platformer.Game.Common;
using UnityEngine;

namespace Platformer.Game.Player
{
    public class PlayerBomb : MonoBehaviour
    {
        #region Variables

        [SerializeField] private Rigidbody2D _rb;

        [SerializeField] private float _speed = 10f;
        [SerializeField] private float _lifetime = 3f;
        [SerializeField] private int _damage = 2;
        [SerializeField] private BombAnimation _bombAnimation;
        [SerializeField] private float _blastRadius = 5f;
        [SerializeField] private LayerMask _playerLayer;

        #endregion

        #region Unity lifecycle

        private void Start()
        {
            _rb.velocity = transform.right * _speed;

            StartCoroutine(DestroyWithLifetimeDelay());
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, _blastRadius);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            Explode();
        }

        #endregion

        #region Private methods

        private IEnumerator DestroyWithLifetimeDelay()
        {
            yield return new WaitForSeconds(_lifetime);
            Explode();
        }

        private void Explode()
        {
            _bombAnimation.TriggerExplosion();

            Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, _blastRadius, _playerLayer);
            foreach (Collider2D collider in colliders)
            {
                if (collider.TryGetComponent(out IDamageable hp))
                {
                    hp.ApplyDamage(_damage);
                }
            }

            Destroy(gameObject);
        }

        #endregion
    }
}