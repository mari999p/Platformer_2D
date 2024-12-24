using Platformer.Game.Player;
using Platformer.Game.Player.Base;
using Platformer.Service.Input;
using Platformer.Service.LevelCompletion;
using Platformer.Service.Mission;
using UnityEngine;
using Zenject;

namespace Platformer.Infrastructure.State
{
    public class GameState : AppState
    {
        #region Variables

        private readonly IInputService _inputService;
        private readonly LevelCompletionService _levelCompletionService;
        private readonly MissionService _missionService;

        #endregion

        #region Setup/Teardown

        [Inject]
        public GameState(LevelCompletionService levelCompletionService,IInputService inputService, MissionService missionService)
        {
            _levelCompletionService = levelCompletionService;
            _inputService = inputService;
            _missionService = missionService;
        }

        #endregion

        #region Public methods

        public override void Enter()
        {
            _levelCompletionService.Initialize();
            Object.FindObjectOfType<PlayerMovement>();
            _inputService.Initialize();
        }

        public override void Exit()
        {
            _levelCompletionService.Dispose();
            _inputService.Dispose();
        }

        #endregion

      
    }
}