using Platformer.Game.Enemy.Animation;
using UnityEngine;

namespace Platformer.Game.Enemy.EnemyAttacks
{
    public abstract class EnemyAttack : EnemyBehaviour
    {
        #region Variables

        public bool needAttack;
        [Header(nameof(EnemyAttack))]
        [SerializeField] private EnemyAnimation _animation;
        [SerializeField] private float _attackDelay = 1f;
        private float _nextAttackTime;

        #endregion

        #region Properties

        protected EnemyAnimation Animation => _animation;
        protected Transform Target { get; private set; }

        #endregion

        #region Unity lifecycle

        protected virtual void Update()
        {
            if (!needAttack)
            {
                return;
            }

            if (Time.time >= _nextAttackTime)
            {
                _nextAttackTime = Time.time + _attackDelay;
                OnPerformAttack();
            }
        }

        #endregion

        #region Public methods

        public void StartAttack(Transform target)
        {
            Target = target;
            needAttack = true;
        }

        public void StopAttack()
        {
            needAttack = false;
        }

        #endregion

        #region Protected methods

        protected virtual void OnPerformAttack()
        {
            _animation.EnemyAttack();
        }

        #endregion
    }
}