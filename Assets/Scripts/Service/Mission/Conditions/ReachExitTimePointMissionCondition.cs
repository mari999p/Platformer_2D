using Platformer.Game.Common;
using UnityEngine;

namespace Platformer.Service.Mission.Conditions
{
    public class ReachExitTimePointMissionCondition : MissionCondition
    {
        #region Variables

        [SerializeField] private TriggerObserver _observer;
        [SerializeField] private float _timeLimit = 60f;

        #endregion

        #region Properties

        public TriggerObserver Observer => _observer;
        public float TimeAllowed => _timeLimit;

        #endregion

        #region Public methods

        public void IncreaseTimeAllowed(float additionalTime)
        {
            _timeLimit += additionalTime;
        }

        #endregion
    }
}