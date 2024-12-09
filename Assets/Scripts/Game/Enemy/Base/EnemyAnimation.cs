using System;
using UnityEngine;

namespace Platformer.Game.Enemy.Base
{
    public class EnemyAnimation : MonoBehaviour
    {
        #region Variables

        private static readonly int Attack = Animator.StringToHash("attack");
        private static readonly int Dead = Animator.StringToHash("death");
        private static readonly int Defuse = Animator.StringToHash("defuse");
        private static readonly int Hit = Animator.StringToHash("hit");
        private static readonly int Speed = Animator.StringToHash("speed");
        [SerializeField] private Animator _animator;

        #endregion

        #region Events

        public event Action OnAttackHit;

        #endregion

        #region Public methods

        public void EnemyAttack()
        {
            _animator.SetTrigger(Attack);
        }

        public void SetSpeed(float value)
        {
            _animator.SetFloat(Speed, value);
        }

        public void TriggerDeath()
        {
            _animator.SetTrigger(Dead);
        }

        public void TriggerDefuse()
        {
            _animator.SetTrigger(Defuse);
        }

        public void TriggerHit()
        {
            _animator.SetTrigger(Hit);
        }

        #endregion

        #region Private methods

        private void AttackHit()
        {
            OnAttackHit?.Invoke();
        }

        #endregion
    }
}