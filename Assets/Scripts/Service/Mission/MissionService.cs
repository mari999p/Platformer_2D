using System;
using Platformer.Game.Player;
using Platformer.Utils.Log;
using UnityEngine;

namespace Platformer.Service.Mission
{
    public class MissionService : MonoBehaviour
    {
        #region Variables

        [SerializeField] private GameObject _exitPoint;
        [SerializeField] private float _missionDuration = 60f;
        [SerializeField] private PlayerMovement _playerMovement;
        [SerializeField] private bool _missionCompleted;
        [SerializeField] private bool _missionStarted;
        [SerializeField] private float _timeRemaining;

        #endregion

        #region Events

        public event Action OnMissionComplete;
        public event Action<float> OnTimeAdded;

        #endregion

        #region Properties

        public bool MissionCompleted => _missionCompleted;
        public float MissionDuration => _missionDuration;

        #endregion

        #region Unity lifecycle

        private void Start()
        {
            _playerMovement = FindObjectOfType<PlayerMovement>();
            if (_playerMovement == null)
            {
                return;
            }

            _timeRemaining = _missionDuration;
            _missionStarted = true;
            _missionCompleted = false;
        }

        private void Update()
        {
            if (!_missionStarted || _missionCompleted)
            {
                return;
            }

            _timeRemaining -= Time.deltaTime;

            if (_timeRemaining <= 0)
            {
                EndMission(false);
            }
            else if (Vector2.Distance(_playerMovement.transform.position, _exitPoint.transform.position) < 0.5f)
            {
                EndMission(true);
            }
        }

        #endregion

        #region Public methods

        public void AddTime(float timeToAdd)
        {
            _timeRemaining += timeToAdd;
            OnTimeAdded?.Invoke(timeToAdd);
        }

        #endregion

        #region Private methods

        private void EndMission(bool success)
        {
            _missionStarted = false;
            _missionCompleted = true;

            if (success)
            {
                this.Log("Mission Completed Successfully!");
                OnMissionComplete?.Invoke();
            }
            else
            {
                this.Log("Mission Failed! Time is up!");
            }
        }

        #endregion
    }
}