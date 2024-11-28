using System.Collections;
using Platformer.Common;
using UnityEngine;

namespace Platformer.Player
{
    public class PlayerBomb: MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _rb;
     
        [SerializeField] private float _speed = 10f;
        [SerializeField] private float _lifetime = 3f;
        [SerializeField] private int _damage = 2;
        [SerializeField] private BombAnimation _bombAnimation; 
        private void Start()
        {
            _rb.velocity = transform.right * _speed;

            StartCoroutine(DestroyWithLifetimeDelay());
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out IDamageable hp))
            {
                hp.ApplyDamage(_damage);
            }
            _bombAnimation.TriggerExplosion();
            Destroy(gameObject);

          
        }
        

        private IEnumerator DestroyWithLifetimeDelay()
        {
            yield return new WaitForSeconds(_lifetime);
            Destroy(gameObject);
        }
    
        
    }
}