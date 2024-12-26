using Platformer.Service.LevelLoading;
using Platformer.Service.Mission;
using Platformer.Utils.Log;

namespace Platformer.Service.LevelCompletion
{
    public class LevelCompletionService
    {
        #region Variables

        private readonly LevelLoadingService _levelLoadingService;
        private readonly MissionService _missionService;

        #endregion

        #region Setup/Teardown

        public LevelCompletionService(MissionService missionService, LevelLoadingService levelLoadingService)
        {
            _missionService = missionService;
            _levelLoadingService = levelLoadingService;
        }

        #endregion

        #region Public methods

        public void Dispose()
        {
            _missionService.OnCompleted -= MissionCompletedCallback;
        }

        public void Initialize()
        {
            _missionService.OnCompleted += MissionCompletedCallback;
        }

        #endregion

        #region Private methods

        private void MissionCompletedCallback()
        {
            this.Error();
            // TODO: Show win screen
            if (_levelLoadingService.HasNextLevel())
            {
                _levelLoadingService.EnterNextLevel();
            }
            else
            {
                // TODO:
                this.Error("GAME OVER!");
            }
        }

        #endregion
    }
}