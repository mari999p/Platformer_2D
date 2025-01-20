using Platformer.Game.Common;
using Platformer.Game.Player;
using UnityEngine;

namespace Platformer.Game.PickUps
{
    public class HealthPack : PickUps
    {
        #region Variables

        [Header(nameof(HealthPack))]
        [SerializeField] private int _healthAmount = 20;

        #endregion

        #region Protected methods

        protected override void PerformActions(Collider2D other)
        {
            base.PerformActions(other);
            if (other.CompareTag(Tag.Player))
            {
                other.gameObject.GetComponent<PlayerDeath>().Heal(_healthAmount);
            }
        }

        #endregion
    }
}