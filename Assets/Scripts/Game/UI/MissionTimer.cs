using System;
using Platformer.Service.Mission.ConcreteMissions;
using TMPro;
using UnityEngine;

namespace Platformer.Game.UI
{
    public class MissionTimer : MonoBehaviour
    {
        #region Variables

        [SerializeField] private TMP_Text _timeDisplay;
        [SerializeField] private float _timeRemaining;
        private ReachExitTimePointMission _mission;

        #endregion

        #region Unity lifecycle

        private void Update()
        {
            if (_mission != null && !_mission.IsCompleted)
            {
                _timeRemaining -= Time.deltaTime;

                if (_timeRemaining <= 0)
                {
                    _timeRemaining = 0;
                }

                UpdateTimeDisplay(_timeRemaining);
            }
        }

        #endregion

        #region Public methods

        public void AddTime(float timeToAdd)
        {
            _timeRemaining += timeToAdd;
            if (_mission != null)
            {
                _mission.AddTimeToMission(timeToAdd);
            }

            UpdateTimeDisplay(_timeRemaining);
        }

        public void Initialize(ReachExitTimePointMission mission)
        {
            _mission = mission;
            _timeRemaining = mission.Condition.TimeAllowed;
            mission.OnCompleted += HandleMissionCompleted;
        }

        public void UpdateTimeDisplay(float time)
        {
            TimeSpan timeSpan = TimeSpan.FromSeconds(time);
            _timeDisplay.text = $"{timeSpan.Minutes:D2}:{timeSpan.Seconds:D2}";
        }

        #endregion

        #region Private methods

        private void HandleMissionCompleted()
        {
        }

        #endregion
    }
}