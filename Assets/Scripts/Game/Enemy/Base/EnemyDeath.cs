using Platformer.Game.Common;
using UnityEngine;

namespace Platformer.Game.Enemy.Base
{
    public class EnemyDeath: EnemyBehaviour
    {
        [SerializeField] private UnitHp _hp;
        [SerializeField] private Collider2D _collider;
        [SerializeField] private EnemyAnimation _animation;
        
        public bool IsDead { get; private set; }
        private void OnEnable()
        {
            _hp.OnChanged += HpChangedCallback;
        }

        private void OnDisable()
        {
            _hp.OnChanged -= HpChangedCallback;
        }

        private void Die()
        {
            IsDead = true;
            _collider.enabled = false;
            _animation.PlayDeath();
        }
        private void HpChangedCallback(int hp)
        {
            if (hp > 0 || IsDead)
            {
                return;
            }

            Die();
        }
    }
}