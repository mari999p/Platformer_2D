using System;
using Platformer.Service.Mission;
using TMPro;
using UnityEngine;

namespace Platformer.Game.UI
{
    public class MissionTimer : MonoBehaviour
    {
        #region Variables

        [SerializeField] private TMP_Text _timerText;
        [SerializeField] private MissionService _missionService;
        private bool _missionStarted;
        private float _timeRemaining;

        #endregion

        #region Unity lifecycle

        private void Update()
        {
            if (_missionStarted && _missionService != null && !_missionService.MissionCompleted)
            {
                UpdateTimerUI();
            }
        }

        private void OnEnable()
        {
            if (_missionService != null)
            {
                _missionService.OnMissionComplete += HandleMissionComplete;
                _missionStarted = true;
                _timeRemaining = _missionService.MissionDuration;
            }
        }

        private void OnDisable()
        {
            if (_missionService != null)
            {
                _missionService.OnMissionComplete -= HandleMissionComplete;
            }
        }

        #endregion

        #region Private methods

        private void HandleMissionComplete()
        {
            _missionStarted = false;
        }

        private void UpdateTimerUI()
        {
            _timeRemaining -= Time.deltaTime;
            if (_timeRemaining < 0)
            {
                _timeRemaining = 0;
            }

            TimeSpan timeSpan = TimeSpan.FromSeconds(_timeRemaining);
            _timerText.text = $"{timeSpan.Minutes:D2}:{timeSpan.Seconds:D2}";
        }

        #endregion
    }
}