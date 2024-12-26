using System.Collections.Generic;
using Platformer.Service.Mission.Conditions;

namespace Platformer.Service.Mission.ConcreteMissions
{
    public class OrCompositeMission : Mission<OrCompositeMissionCondition>
    {
        #region Variables

        private readonly List<Mission> _missions = new();

        private MissionFactory _factory;

        #endregion

        #region Public methods

        public void Setup(MissionFactory factory)
        {
            _factory = factory;
        }

        #endregion

        #region Protected methods

        protected override void OnBegin()
        {
            base.OnBegin();

            foreach (MissionCondition missionCondition in Condition.Conditions)
            {
                Mission mission = _factory.Create(missionCondition);
                mission.OnCompleted += MissionCompletedCallback;
                mission.Begin();
                _missions.Add(mission);
            }
        }

        protected override void OnStop()
        {
            base.OnStop();

            foreach (Mission mission in _missions)
            {
                mission.OnCompleted -= MissionCompletedCallback;
                mission.Stop();
            }
        }

        protected override void OnUpdate()
        {
            base.OnUpdate();

            foreach (Mission mission in _missions)
            {
                mission.Update();
            }
        }

        #endregion

        #region Private methods

        private void MissionCompletedCallback()
        {
            InvokeCompletion();
        }

        #endregion
    }
}