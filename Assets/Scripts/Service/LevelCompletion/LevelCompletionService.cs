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

        public LevelCompletionService(LevelLoadingService levelLoadingService, MissionService missionService)
        {
            _levelLoadingService = levelLoadingService;
            _missionService = missionService;
        }

        public void Initialize()
        {
            _missionService.OnMissionComplete += HandleMissionComplete;
        }

        public void Dispose()
        {
            _missionService.OnMissionComplete -= HandleMissionComplete;
        }

        private void HandleMissionComplete()
        {
            if (_levelLoadingService.HasNextLevel())
            {
                _levelLoadingService.EnterNextLevel();
            }
            else
            {
                this.Log("All levels completed!");
            }
        }

        #endregion
    }
}