using System.Collections;
using Platformer.Game.Enemy.Base;
using Platformer.Game.Objects.Bomb;
using UnityEngine;

namespace Platformer.Game.Enemy

{
    public class EnemyDefuseBomb : EnemyBehaviour
    {
        #region Variables

        [Header(nameof(EnemyDefuseBomb))]
        public bool isDefusing;
        [SerializeField] private EnemyAnimation _defuseAnimation;
        [SerializeField] private LayerMask _bombLayer;
        [SerializeField] private EnemyDeath _enemyDeath;
        [SerializeField] private float _defuseRadius = 2f;
        [SerializeField] private float _timeOfDeactivation = 1;

        private bool _bombNearby;

        #endregion

        #region Unity lifecycle

        private void Awake()
        {
            _enemyDeath.OnHappened += OnEnemyDeath;
        }

        private void Update()
        {
            CheckForBombs();

            if (_bombNearby)

            {
                DefuseBomb();
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

        private void DefuseBomb()
        {
            if (!isDefusing)
            {
                isDefusing = true;
                _defuseAnimation.TriggerDefuse();
                StartCoroutine(DefusingCoroutine());
            }
        }

        private IEnumerator DefusingCoroutine()
        {
            yield return new WaitForSeconds(_timeOfDeactivation);
            Collider2D[] bombs = Physics2D.OverlapCircleAll(transform.position, _defuseRadius, _bombLayer);
            foreach (Collider2D bombCollider in bombs)
            {
                if (bombCollider.TryGetComponent(out Bomb bomb))
                {
                    bomb.Defuse();
                }
            }

            isDefusing = false;
        }

        private void OnEnemyDeath()
        {
            enabled = false;
        }

        #endregion
    }
}