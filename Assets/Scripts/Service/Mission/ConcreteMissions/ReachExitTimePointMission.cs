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

        #endregion

        #region Properties

        public float ElapsedTime => _elapsedTime;

        #endregion

        #region Public methods

        public void InvokeFailure()
        {
            this.Log("Миссия не выполнена: время истекло!");
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
        }

        #endregion

        #region Private methods

        private void ObserverEnteredCallback(Collider2D col)
        {
            if (col.CompareTag(Tag.Player))
            {
                InvokeCompletion();
            }
        }

        #endregion
    }
}