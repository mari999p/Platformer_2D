using System;
using Platformer.Game.UI;
using Platformer.Service.Mission.ConcreteMissions;
using Platformer.Utils.Log;
using UnityEngine;
using UnityEngine.Assertions;

namespace Platformer.Service.Mission
{
    public class MissionService : MonoBehaviour
    {
        #region Variables

        private readonly MissionFactory _factory = new();

        private Mission _currentMission;
        private MissionTimer _missionTimer;

        #endregion

        #region Events

        public event Action OnCompleted;
        public event Action OnStarted;

        #endregion

        #region Unity lifecycle

        private void Update()
        {
            _currentMission?.Update();
        }

        #endregion

        #region Public methods

        public void Begin()
        {
            Assert.IsNotNull(_currentMission);
            _currentMission.Begin();
            OnStarted?.Invoke();
        }

        public void Dispose()
        {
            if (_currentMission != null)
            {
                _currentMission.OnCompleted -= MissionCompletedCallback;
                _currentMission.Stop();
            }

            _currentMission = null;
        }

        public void Initialize()
        {
            MissionConditionHolder holder = FindObjectOfType<MissionConditionHolder>();
            if (holder == null)
            {
                this.Error("MissionConditionHolder not found in the scene.");
                return;
            }

            _currentMission = _factory.Create(holder.MissionCondition);
            _currentMission.OnCompleted += MissionCompletedCallback;
            _missionTimer = FindObjectOfType<MissionTimer>();

            if (_missionTimer != null)
            {
                _missionTimer.Initialize((ReachExitTimePointMission)_currentMission);
            }
            else
            {
                this.Error("MissionTimer not found in the scene.");
            }
        }

        #endregion

        #region Private methods

        private void MissionCompletedCallback()
        {
            OnCompleted?.Invoke();
        }

        #endregion
    }
}