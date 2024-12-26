using Platformer.Service.Mission.ConcreteMissions;
using Platformer.Service.Mission.Conditions;

namespace Platformer.Service.Mission
{
    public class MissionFactory
    {
        #region Public methods

        public Mission Create(MissionCondition condition)
        {
            if (condition is ReachExitTimePointMissionCondition reachExitTimePointMissionCondition)
            {
                ReachExitTimePointMission reachExitTimePointMission = new();
                reachExitTimePointMission.SetCondition(reachExitTimePointMissionCondition);
                return reachExitTimePointMission;
            }

            if (condition is OrCompositeMissionCondition orCompositeMissionCondition)
            {
                OrCompositeMission orCompositeMission = new();
                orCompositeMission.SetCondition(orCompositeMissionCondition);
                orCompositeMission.Setup(this);
                return orCompositeMission;
            }

            return null;
        }

        #endregion
    }
}