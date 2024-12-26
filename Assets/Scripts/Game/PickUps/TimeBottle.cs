using Platformer.Game.Common;
using Platformer.Game.UI;
using UnityEngine;

namespace Platformer.Game.PickUps
{
    public class TimeBottle : PickUps
    {
        #region Variables

        [Header(nameof(TimeBottle))]
        [SerializeField] private float _timeToAdd = 10f;

        #endregion

        #region Protected methods

        protected override void PerformActions(Collider2D other)
        {
            base.PerformActions(other);
            if (other.CompareTag(Tag.Player))
            {
                MissionTimer missionTimer = FindObjectOfType<MissionTimer>();
                if (missionTimer != null)
                {
                    missionTimer.AddTime(_timeToAdd);
                }
            }
        }

        #endregion
    }
}