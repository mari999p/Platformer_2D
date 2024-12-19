using UnityEngine;

namespace Platformer.Game.Player.Base
{
    public class GameEffectsAnimation : MonoBehaviour
    {
        #region Variables

        private static readonly int JumpParticles = Animator.StringToHash("jumpParticles");
        [SerializeField] private Animator _animator;

        #endregion

        #region Public methods

        public void TriggerJumpParticles()
        {
            _animator.SetTrigger(JumpParticles);
        }

        #endregion
    }
}