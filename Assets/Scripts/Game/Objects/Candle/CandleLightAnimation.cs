using UnityEngine;

namespace Platformer.Game.Objects.Candle
{
    public class CandleLightAnimation : MonoBehaviour
    {
        #region Variables

        private static readonly int CandleLight = Animator.StringToHash("candLelight");
        [SerializeField] private Animator _animator;

        #endregion

        #region Public methods

        public void TriggerCandleLight()
        {
            _animator.SetTrigger(CandleLight);
        }

        #endregion
    }
}