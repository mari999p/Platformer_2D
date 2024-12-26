using System.Collections.Generic;
using UnityEngine;

namespace Platformer.Service.Mission.Conditions
{
    public class OrCompositeMissionCondition : MissionCondition
    {
        #region Variables

        [SerializeField] private MissionCondition[] _conditions;

        #endregion

        #region Properties

        public IReadOnlyList<MissionCondition> Conditions => _conditions;

        #endregion
    }
}