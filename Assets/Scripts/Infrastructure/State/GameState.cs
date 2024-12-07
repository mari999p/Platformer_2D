using Platformer.Game.Player.Base;
using Platformer.Service.Input;
using UnityEngine;

namespace Platformer.Infrastructure.State
{
    public class GameState : AppState
    {
        #region Variables

        private readonly IInputService _inputService;

        #endregion

        #region Setup/Teardown

        public GameState(IInputService inputService)
        {
            _inputService = inputService;
        }

        #endregion

        #region Public methods

        public override void Enter()
        {
            PlayerMovement playerMovement = Object.FindObjectOfType<PlayerMovement>();
            _inputService.Initialize(Camera.main, playerMovement.transform);
        }

        public override void Exit()
        {
            _inputService.Dispose();
        }

        #endregion
    }
}