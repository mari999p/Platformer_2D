using UnityEngine;

namespace Platformer.Game.Player.Base
{
    public class PlayerAnimation : MonoBehaviour
    {
        #region Variables

        private static readonly int Attack = Animator.StringToHash("attack");
        private static readonly int Death = Animator.StringToHash("death");
        private static readonly int Jump = Animator.StringToHash("jump");
        private static readonly int Movement = Animator.StringToHash("movement");
        [SerializeField] private Animator _animator;

        #endregion

        #region Public methods

        public void SetMovement(float speed)
        {
            _animator.SetFloat(Movement, speed);
        }

        public void TriggerAttack()
        {
            _animator.SetTrigger(Attack);
        }

        public void TriggerDeath()
        {
            _animator.SetTrigger(Death);
        }

        public void TriggerJump()
        {
            _animator.SetTrigger(Jump);
        }

        #endregion
    }
}