using System;
using UnityEngine;

namespace Platformer.Game.Enemy.Base
{
    public class EnemyAnimation: MonoBehaviour
    {
        private static readonly int Attack = Animator.StringToHash("attack");
        private static readonly int Dead = Animator.StringToHash("death");
        private static readonly int Speed = Animator.StringToHash("speed");
        public event Action OnAttackHit;
        [SerializeField] private Animator _animator;
        
        public void PlayAttack()
        {
            _animator.SetTrigger(Attack);
        }

        public void PlayDeath()
        {
            _animator.SetTrigger(Dead);
        }

        public void SetSpeed(float value)
        {
            _animator.SetFloat(Speed, value);
        }
        private void AttackHit()
        {
            OnAttackHit?.Invoke();
        }
    }
}