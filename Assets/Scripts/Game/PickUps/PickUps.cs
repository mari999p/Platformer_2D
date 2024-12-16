using Platformer.Game.Common;
using UnityEngine;

namespace Platformer.Game.PickUps
{
    public class PickUps: MonoBehaviour
    {
        #region Unity lifecycle

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag(Tag.Player))
            {
                PerformActions(other);
                Destroy(gameObject);
            }
        }

        #endregion

        #region Protected methods

        protected virtual void PerformActions(Collider2D other) { }

        #endregion
    }
}