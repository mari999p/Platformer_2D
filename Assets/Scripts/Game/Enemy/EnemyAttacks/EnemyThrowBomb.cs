using System.Collections;
using Platformer.Game.Common;
using Platformer.Game.Enemy.Animation;
using Platformer.Game.Objects.Bomb;
using UnityEngine;

namespace Platformer.Game.Enemy.EnemyAttacks
{
    public class EnemyThrowBomb : MonoBehaviour
    {
        #region Variables

        [Header(nameof(EnemyThrowBomb))]
        public bool isDefusing;
        [SerializeField] private EnemyAnimation _defuseAnimation;
        [SerializeField] private LayerMask _bombLayer;
        [SerializeField] private EnemyDeath _enemyDeath;
        [SerializeField] private float _defuseRadius = 2f;
        [SerializeField] private float _throwForce = 5f;

        [SerializeField] private AudioClip _throwSound;
        [SerializeField] private AudioSource _audioSource;
        private bool _bombNearby;

        #endregion

        #region Unity lifecycle

        private void Awake()
        {
            _enemyDeath.OnHappened += OnEnemyDeath;
            _audioSource = gameObject.AddComponent<AudioSource>();
        }

        private void Update()
        {
            CheckForBombs();
            if (_bombNearby)
            {
                DefuseAndThrowBomb();
            }
        }

        private void OnDestroy()
        {
            _enemyDeath.OnHappened -= OnEnemyDeath;
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, _defuseRadius);
        }

        #endregion

        #region Private methods

        private void CheckForBombs()
        {
            Collider2D[] bombs = Physics2D.OverlapCircleAll(transform.position, _defuseRadius, _bombLayer);
            _bombNearby = bombs.Length > 0;
        }

        private void DefuseAndThrowBomb()
        {
            if (!isDefusing)
            {
                isDefusing = true;
                _defuseAnimation.TriggerDefuse();
                StartCoroutine(DefusingAndThrowingCoroutine());
            }
        }

        private IEnumerator DefusingAndThrowingCoroutine()
        {
            yield return new WaitForSeconds(0.5f);
            Collider2D[] bombs = Physics2D.OverlapCircleAll(transform.position, _defuseRadius, _bombLayer);

            GameObject player = GameObject.FindGameObjectWithTag(Tag.Player);
            Vector2 playerPosition = player != null ? player.transform.position : Vector2.zero;

            foreach (Collider2D bombCollider in bombs)
            {
                if (bombCollider.TryGetComponent(out Bomb bomb))
                {
                    bomb.DefuseWithFist();
                    Rigidbody2D bombRigidbody = bomb.GetComponent<Rigidbody2D>();

                    if (bombRigidbody != null)
                    {
                        Vector2 throwDirection = (playerPosition - (Vector2)transform.position).normalized;
                        throwDirection.y = 1;
                        bombRigidbody.AddForce(throwDirection * _throwForce, ForceMode2D.Impulse);

                        PlayThrowSound();
                    }
                }
            }

            isDefusing = false;
        }

        private void OnEnemyDeath()
        {
            enabled = false;
        }

        private void PlayThrowSound()
        {
            if (_throwSound != null && _audioSource != null)
            {
                _audioSource.PlayOneShot(_throwSound);
            }
        }

        #endregion
    }
}