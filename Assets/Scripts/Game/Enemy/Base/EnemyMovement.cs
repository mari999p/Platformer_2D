using UnityEngine;

namespace Platformer.Game.Enemy.Base
{
    public abstract class EnemyMovement: EnemyBehaviour
    {
        [SerializeField] private EnemyAnimation _animation;
        protected EnemyAnimation Animation => _animation;
        public abstract void SetTarget(Transform target);

    }
}