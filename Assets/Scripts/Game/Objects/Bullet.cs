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
        private Vector2 _direction;
        #endregion

        #region Unity lifecycle

        private void Start()
        {
            _rb.velocity = _direction * _speed;
            StartCoroutine(DestroyWithLifetimeDelay());
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out UnitHp hp))
            {
                hp.Change(-_damage);
            }

            Destroy(gameObject);
        }
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