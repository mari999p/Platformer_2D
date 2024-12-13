using System.Collections;
using Platformer.Game.Enemy.Base;
using Platformer.Game.Objects.Bomb;
using UnityEngine;

namespace Platformer.Game.Enemy
{
    public class EnemyThrowBomb : EnemyBehaviour
    {
        #region Variables
        [Header(nameof(EnemyThrowBomb))]
        public bool isDefusing;
        [SerializeField] private EnemyAnimation _defuseAnimation;
        [SerializeField] private LayerMask _bombLayer;
        [SerializeField] private float _defuseRadius = 2f;
        [SerializeField] private float _throwForce = 5f;
        private bool _bombNearby;

        #endregion

        #region Unity lifecycle

        private void Update()
        {
            CheckForBombs();
            if (_bombNearby)
            {
                DefuseAndThrowBomb();
            }
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

            foreach (Collider2D bombCollider in bombs)
            {
                if (bombCollider.TryGetComponent(out Bomb bomb))
                {
                    bomb.DefuseWithFist();
                    Rigidbody2D bombRigidbody = bomb.GetComponent<Rigidbody2D>();

                    if (bombRigidbody != null)
                    {
                        Vector2 throwDirection = (Vector2.up + Vector2.right).normalized;
                        bombRigidbody.AddForce(throwDirection * _throwForce, ForceMode2D.Impulse);
                    }
                }
            }

            isDefusing = false;
        }

        #endregion
    }
}