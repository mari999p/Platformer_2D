using System;
using Platformer.Game.Common;
using Platformer.Service.Mission.Conditions;
using Platformer.Utils.Log;
using UnityEngine;

namespace Platformer.Service.Mission.ConcreteMissions
{
    public class ReachExitTimePointMission : Mission<ReachExitTimePointMissionCondition>
    {
        #region Variables

        private float _elapsedTime;
        private bool _playerInTriggerZone;

        #endregion

        #region Events

        public event Action OnFailed;

        #endregion

        #region Public methods

        public void AddTimeToMission(float time)
        {
            Condition.IncreaseTimeAllowed(time);
        }

        public void InvokeFailure()
        {
            this.Log("Миссия не выполнена: время истекло!");
            OnFailed?.Invoke();
            Stop();
        }

        #endregion

        #region Protected methods

        protected override void OnBegin()
        {
            base.OnBegin();
            _elapsedTime = 0f;
            Condition.Observer.OnEntered += ObserverEnteredCallback;
        }

        protected override void OnStop()
        {
            base.OnStop();

            Condition.Observer.OnEntered -= ObserverEnteredCallback;
        }

        protected override void OnUpdate()
        {
            base.OnUpdate();
            _elapsedTime += Time.deltaTime;
            if (_elapsedTime >= Condition.TimeAllowed)
            {
                InvokeFailure();
            }

            if (_playerInTriggerZone && UnityEngine.Input.GetKeyDown(KeyCode.E))
            {
                Condition.DoorAnimation?.OpenDoor();
                Condition.PlayerAnimation.TriggerEnterDoor();
                InvokeCompletion();
            }
        }

        #endregion

        #region Private methods

        private void ObserverEnteredCallback(Collider2D col)
        {
            if (col.CompareTag(Tag.Player))
            {
                _playerInTriggerZone = true;
            }
        }

        private void ObserverExitedCallback(Collider2D col)
        {
            if (col.CompareTag(Tag.Player))
            {
                _playerInTriggerZone = false;
            }
        }

        #endregion
    }
}