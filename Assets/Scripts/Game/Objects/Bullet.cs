using System.Collections;
using Platformer.Game.Common;
using UnityEngine;

namespace Platformer.Game.Objects
{
    public class Bullet : MonoBehaviour
    {
        #region Variables

        [SerializeField] private Rigidbody2D _rb;
        [SerializeField] private float _speed = 10f;
        [SerializeField] private float _lifetime = 3f;
        [SerializeField] private int _damage = 2;

        [SerializeField] private AudioClip _flyingSound;
        [SerializeField] private AudioSource _audioSource;
        private Vector2 _direction;

        #endregion

        #region Unity lifecycle

        private void Start()
        {
            _rb.velocity = _direction * _speed;
            if (_audioSource != null && _flyingSound != null)
            {
                _audioSource.PlayOneShot(_flyingSound);
            }

            StartCoroutine(DestroyWithLifetimeDelay());
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.collider.TryGetComponent(out UnitHp hp))
            {
                hp.Change(-_damage);
            }

            // Destroy(gameObject);
        }

        #endregion

        #region Public methods

        public void SetDirection(Vector2 direction)
        {
            _direction = direction.normalized;
        }

        #endregion

        #region Private methods

        private IEnumerator DestroyWithLifetimeDelay()
        {
            yield return new WaitForSeconds(_lifetime);
            Destroy(gameObject);
        }

        #endregion
    }
}