using Platformer.Infrastructure.State;
using UnityEngine;

namespace Platformer.Service.LevelLoading
{
    public class LevelLoadingService
    {
        #region Variables

        private const string ConfigPath = "Configs/Levels/LevelLoadingConfig";

        private readonly StateMachine _stateMachine;

        private LevelLoadingConfig _config;
        private int _levelIndex;

        #endregion

        #region Setup/Teardown

        public LevelLoadingService(StateMachine stateMachine)
        {
            _stateMachine = stateMachine;
        }

        #endregion

        #region Public methods

        public void EnterFirstLevel()
        {
            _levelIndex = 0;
            EnterLevel();
        }

        public void EnterNextLevel()
        {
            if (!HasNextLevel())
            {
                return;
            }

            _levelIndex++;
            EnterLevel();
        }

        public bool HasNextLevel()
        {
            return _levelIndex < _config.LevelSceneNames.Count - 1;
        }

        public void Initialize()
        {
            _config = Resources.Load<LevelLoadingConfig>(ConfigPath);
        }

        #endregion

        #region Private methods

        private void EnterLevel()
        {
            _stateMachine.Enter<LoadGameState, string>(_config.LevelSceneNames[_levelIndex]);
        }

        #endregion
    }
}