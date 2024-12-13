using UnityEngine;

namespace Platformer.Game.Objects.Chain
{
    public class ChainController : MonoBehaviour
    {
        #region Variables

        [SerializeField] private ChainAnimation _animation;

        #endregion

        #region Unity lifecycle

        private void Update()
        {
            _animation.TriggerBurn();
        }

        #endregion
    }
}