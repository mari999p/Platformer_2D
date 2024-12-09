using UnityEngine;

namespace Platformer.Game.Objects.Candle
{
    public class CandleAnimation : MonoBehaviour
    {
        #region Variables

        private static readonly int Burn = Animator.StringToHash("burn");
        [SerializeField] private Animator _animator;

        #endregion

        #region Public methods

        public void TriggerBurn()
        {
            _animator.SetTrigger(Burn);
        }

        #endregion
    }
}