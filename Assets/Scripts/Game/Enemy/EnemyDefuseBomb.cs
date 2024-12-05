using Platformer.Game.Enemy.Base;
using UnityEngine;

namespace Platformer.Game.Enemy
{
    public class EnemyDefuseBomb : EnemyBehaviour
    {
        #region Variables

        [SerializeField] private EnemyAnimation _defuseAnimation;
        [SerializeField] private float _defuseRadius = 2f;
        [SerializeField] private LayerMask _bombLayer;
        private bool _bombNearby;

        #endregion

        #region Unity lifecycle

        private void Update()
        {
            CheckForBombs();
            if (_bombNearby)
            {
                DefuseBomb();
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

        private void DefuseBomb()
        {
            _defuseAnimation.TriggerDefuse();
        }

        #endregion
    }
}