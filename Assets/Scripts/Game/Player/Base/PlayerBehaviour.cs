using UnityEngine;

namespace Platformer.Game.Player.Base
{
    public abstract class PlayerBehaviour : MonoBehaviour
    {
        #region Public methods

        public void Activate()
        {
            enabled = true;
        }

        public void Deactivate()
        {
            enabled = false;
        }

        #endregion
    }
}