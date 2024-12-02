using UnityEngine;

namespace Platformer.Game.Enemy.Base
{
    public abstract class  EnemyAttack: EnemyBehaviour
    {
        [Header(nameof(EnemyAttack))]
        [SerializeField] private float _attackDelay = 1f;
        [SerializeField] private EnemyAnimation _animation;

        private bool _needAttack;
        private float _nextAttackTime;
        protected EnemyAnimation Animation => _animation;
        protected Transform Target { get; private set; }
        protected virtual void Update()
        {
            if (!_needAttack)
            {
                return;
            }

            if (Time.time >= _nextAttackTime)
            {
                _nextAttackTime = Time.time + _attackDelay;
                OnPerformAttack();
            }
        }
        public void PerformAttackForced()
        {
            OnPerformAttack();
        }

        public void StartAttack(Transform target)
        {
            Target = target;
            _needAttack = true;
        }

        public void StopAttack()
        {
            _needAttack = false;
        }

       

        protected virtual void OnPerformAttack()
        {
            _animation.PlayAttack();
        }
    }
}