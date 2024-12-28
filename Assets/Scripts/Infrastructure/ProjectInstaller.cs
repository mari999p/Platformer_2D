using Platformer.Infrastructure.State;
using Platformer.Service.Coroutine;
using Platformer.Service.GameOver;
using Platformer.Service.Input;
using Platformer.Service.LevelCompletion;
using Platformer.Service.LevelLoading;
using Platformer.Service.Mission;
using Platformer.Service.Restart;
using Platformer.Service.SceneLoading;
using Platformer.UI;
using Zenject;

namespace Platformer.Infrastructure
{
    public class ProjectInstaller : MonoInstaller
    {
        #region Public methods

        public override void InstallBindings()
        {
            StateMachineInstaller.Install(Container);
            LevelLoadingServiceInstaller.Install(Container);
            SceneLoaderServiceInstaller.Install(Container);
            LevelCompletionServiceInstaller.Install(Container);
            MissionServiceInstaller.Install(Container);
            CoroutineRunnerInstaller.Install(Container);
            InputServiceInstaller.Install(Container);
           GameOverServiceInstaller.Install(Container);
           RestartServiceInstaller.Install(Container);
        }

        #endregion
    }
}