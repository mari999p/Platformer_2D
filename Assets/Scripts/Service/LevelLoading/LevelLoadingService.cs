using System.Collections;
using Platformer.Infrastructure.State;
using Platformer.Service.Coroutine;
using UnityEngine;

namespace Platformer.Service.LevelLoading
{
    public class LevelLoadingService
    {
        #region Variables

        private const string ConfigPath = "Configs/Levels/LevelLoadingConfig";
        private readonly CoroutineRunner _coroutineRunner;

        private readonly StateMachine _stateMachine;
        private LevelLoadingConfig _config;
        private int _levelIndex;

        #endregion

        #region Setup/Teardown

        public LevelLoadingService(StateMachine stateMachine, CoroutineRunner coroutineRunner)
        {
            _stateMachine = stateMachine;
            _coroutineRunner = coroutineRunner;
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
            _coroutineRunner.StartCoroutine(EnterLevelWithDelay());
        }

        private IEnumerator EnterLevelWithDelay()
        {
            yield return new WaitForSeconds(1f);
            _stateMachine.Enter<LoadGameState, string>(_config.LevelSceneNames[_levelIndex]);
        }

        #endregion
    }
}