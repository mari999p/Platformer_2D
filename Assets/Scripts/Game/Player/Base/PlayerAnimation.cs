using UnityEngine;

namespace Platformer.Game.Player.Base
{
    public class PlayerAnimation : MonoBehaviour
    {
        #region Variables

        private static readonly int Attack = Animator.StringToHash("attack");
        private static readonly int Dead = Animator.StringToHash("death");
        private static readonly int EnterDoor = Animator.StringToHash("enterDoor");
        private static readonly int ExitDoor = Animator.StringToHash("exitDoor");
        private static readonly int Hit = Animator.StringToHash("hit");
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
            _animator.SetTrigger(Dead);
        }

        public void TriggerEnterDoor()
        {
            _animator.SetTrigger(EnterDoor);
        }

        public void TriggerExitDoor()
        {
            _animator.SetTrigger(ExitDoor);
        }

        public void TriggerHit()
        {
            _animator.SetTrigger(Hit);
        }

        public void TriggerJump()
        {
            _animator.SetTrigger(Jump);
        }

        #endregion
    }
}