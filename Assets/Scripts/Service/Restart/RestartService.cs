using Platformer.Infrastructure.State;
using UnityEngine.SceneManagement;

namespace Platformer.Service.Restart
{
    public class RestartService : IRestartService
    {
        #region Variables

        private readonly StateMachine _stateMachine;

        #endregion

        #region Setup/Teardown

        public RestartService(StateMachine stateMachine)
        {
            _stateMachine = stateMachine;
        }

        #endregion

        #region IRestartService

        public void RestartCurrentScene()
        {
            string currentSceneName = SceneManager.GetActiveScene().name;
            _stateMachine.Enter<LoadGameState, string>(currentSceneName);
        }

        #endregion
    }
}