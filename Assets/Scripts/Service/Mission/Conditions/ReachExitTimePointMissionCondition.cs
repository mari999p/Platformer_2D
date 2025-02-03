using Platformer.Game.Common;
using Platformer.Game.Objects.Door;
using Platformer.Game.Player.Animation;
using UnityEngine;

namespace Platformer.Service.Mission.Conditions
{
    public class ReachExitTimePointMissionCondition : MissionCondition
    {
        #region Variables

        [SerializeField] private TriggerObserver _observer;
        [SerializeField] private float _timeLimit = 60f;
        [SerializeField] private DoorAnimation _doorAnimation;
        [SerializeField] private PlayerAnimation _playerAnimation;

        #endregion

        #region Properties

        public DoorAnimation DoorAnimation => _doorAnimation;
        public TriggerObserver Observer => _observer;
        public PlayerAnimation PlayerAnimation => _playerAnimation;
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