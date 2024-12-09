using UnityEngine;

namespace Platformer.Game.Objects.Candle
{
    public class CandleController : MonoBehaviour
    {
        #region Variables

        [SerializeField] private CandleAnimation _candleAnimation;
        [SerializeField] private CandleLightAnimation _candleLightAnimation;

        #endregion

        #region Unity lifecycle

        private void Update()
        {
            _candleAnimation.TriggerBurn();
            _candleLightAnimation.TriggerCandleLight();
        }

        #endregion
    }
}