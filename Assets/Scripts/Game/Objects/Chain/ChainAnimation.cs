using UnityEngine;

namespace Platformer.Game.Objects.Chain
{
    public class ChainAnimation : MonoBehaviour
    {
        #region Variables

        private static readonly int Chain = Animator.StringToHash("chain");
        [SerializeField] private Animator _animator;

        #endregion

        #region Public methods

        public void TriggerBurn()
        {
            _animator.SetTrigger(Chain);
        }

        #endregion
    }
}