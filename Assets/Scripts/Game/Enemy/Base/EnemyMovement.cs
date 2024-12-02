using UnityEngine;

namespace Platformer.Game.Enemy.Base
{
    public abstract class EnemyMovement : EnemyBehaviour
    {
        #region Variables

        [SerializeField] private EnemyAnimation _animation;

        #endregion

        #region Properties

        protected EnemyAnimation Animation => _animation;

        #endregion

        #region Public methods

        public abstract void SetTarget(Transform target);

        #endregion
    }
}