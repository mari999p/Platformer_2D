using System.Collections;
using Platformer.Game.Common;
using UnityEngine;

namespace Platformer.Game.Player
{
    public class Bomb : MonoBehaviour
    {
        #region Variables

        [SerializeField] private Rigidbody2D _rb;

        [SerializeField] private float _speed = 10f;
        [SerializeField] private float _lifetime = 3f;
        [SerializeField] private int _damage = 2;
        [SerializeField] private BombAnimation _bombAnimation;
        [SerializeField] private float _blastRadius = 5f;
        [SerializeField] private LayerMask _playerLayer;
        private Vector3 _direction;
        #endregion

        #region Unity lifecycle
        private void Update()
        {
            transform.position += _direction * (_speed * Time.deltaTime);
        }
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
            foreach (Collider2D collider1 in colliders)
            {
                if (collider1.TryGetComponent(out IDamageable hp))
                {
                    hp.ApplyDamage(_damage);
                }
            }

            Destroy(gameObject);
        }

        #endregion

        public void SetDirection(Vector3 direction)
        {
            _direction = direction;
        }

        public void SetSpeed(float bombSpeed)
        { 
            _speed = bombSpeed; 
        }
    }
}