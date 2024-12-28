using Platformer.Game.Common;
using Platformer.Game.Player;
using UnityEngine;

namespace Platformer.Game.PickUps
{
    public class GoldCoinPack : PickUps
    {
        #region Variables

        [Header(nameof(GoldCoinPack))]
        [SerializeField] private int _goldAmount = 10;

        #endregion

        #region Protected methods

        protected override void PerformActions(Collider2D other)
        {
            base.PerformActions(other);
            if (other.CompareTag(Tag.Player))
            {
                PlayerInventory playerInventory = other.GetComponent<PlayerInventory>();

                playerInventory.AddCoins(_goldAmount);
            }
        }

        #endregion
    }
}