using Platformer.Infrastructure.State;
using Platformer.Service.Input;
using Platformer.Service.LevelCompletion;
using Platformer.Service.LevelLoading;
using Platformer.Service.Mission;
using Zenject;

namespace Platformer.Infrastructure
{
    public class ProjectInstaller : MonoInstaller
    {
        #region Public methods

        public override void InstallBindings()
        {
            InputServiceInstaller.Install(Container);
            StateMachineInstaller.Install(Container);
            MissionServiceInstaller.Install(Container);
            LevelLoadingServiceInstaller.Install(Container);
            LevelCompletionServiceInstaller.Install(Container);
        }

        #endregion
    }
}