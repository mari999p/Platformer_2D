using Platformer.Game.Player;
using Platformer.Game.Player.Base;
using Platformer.Service.Input;
using Platformer.Service.Mission;
using UnityEngine;
using Zenject;

namespace Platformer.Infrastructure.State
{
    public class GameState : AppState
    {
        #region Variables

        private readonly IInputService _inputService;
        private readonly MissionService _missionService;

        #endregion

        #region Setup/Teardown

        [Inject]
        public GameState(IInputService inputService, MissionService missionService)
        {
            _inputService = inputService;
            _missionService = missionService;
        }

        #endregion

        #region Public methods

        public override void Enter()
        {
            Object.FindObjectOfType<PlayerMovement>();
            _missionService.OnMissionComplete += HandleMissionComplete;
            _inputService.Initialize();
        }

        public override void Exit()
        {
            _missionService.OnMissionComplete -= HandleMissionComplete;
            _inputService.Dispose();
        }

        #endregion

        #region Private methods

        private void HandleMissionComplete()
        {
            Debug.Log("StateMachine: Mission Completed");
        }

        #endregion
    }
}