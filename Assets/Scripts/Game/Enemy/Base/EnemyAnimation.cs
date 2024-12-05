using System;
using UnityEngine;

namespace Platformer.Game.Enemy.Base
{
    public class EnemyAnimation: MonoBehaviour
    {
        private static readonly int Attack = Animator.StringToHash("attack");
        private static readonly int Dead = Animator.StringToHash("death");
        private static readonly int Speed = Animator.StringToHash("speed");
        private static readonly int Hit = Animator.StringToHash("hit"); 
        private static readonly int Defuse = Animator.StringToHash("defuse");
        public event Action OnAttackHit;
        [SerializeField] private Animator _animator;
        
        public void EnemyAttack()
        {
            _animator.SetTrigger(Attack);
        }

        public void SetSpeed(float value)
        {
            _animator.SetFloat(Speed, value);
        }
        private void AttackHit()
        {
            OnAttackHit?.Invoke();
        }
        public void TriggerHit()
        {
            _animator.SetTrigger(Hit);
        }

        public void TriggerDeath()
        {
            _animator.SetTrigger(Dead);
        }
        public void TriggerDefuse()
        {
            _animator.SetTrigger(Defuse);
        }
    }
}