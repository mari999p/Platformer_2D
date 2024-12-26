using Platformer.Service.LevelLoading;

namespace Platformer.Infrastructure.State
{
    public class BootstrapState : AppState
    {
        #region Variables

        private readonly LevelLoadingService _levelLoadingService;

        #endregion

        #region Setup/Teardown

        public BootstrapState(LevelLoadingService levelLoadingService)
        {
            _levelLoadingService = levelLoadingService;
        }

        #endregion

        #region Public methods

        public override void Enter()
        {
            _levelLoadingService.Initialize();
            _levelLoadingService.EnterFirstLevel();
        }

        public override void Exit() { }

        #endregion
    }
}