using System.Collections;
using Platformer.Service.Coroutine;
using Platformer.Service.SceneLoading;

namespace Platformer.Infrastructure.State
{
    public class LoadGameState : PayloadAppState<string>
    {
        #region Variables

        private readonly CoroutineRunner _coroutineRunner;
        private readonly SceneLoaderService _sceneLoaderService;

        #endregion

        #region Setup/Teardown

        public LoadGameState(SceneLoaderService sceneLoaderService, CoroutineRunner coroutineRunner)
        {
            _sceneLoaderService = sceneLoaderService;
            _coroutineRunner = coroutineRunner;
        }

        #endregion

        #region Public methods

        public override void Enter(string sceneName)
        {
            _sceneLoaderService.Load(sceneName);
            _coroutineRunner.StartCoroutine(EnterGameWithDelay());
        }

        public override void Exit() { }

        #endregion

        #region Private methods

        private IEnumerator EnterGameWithDelay()
        {
            yield return null;
            StateMachine.Enter<GameState>();
        }

        #endregion
    }
}