using Platformer.Infrastructure.State;
using Platformer.Service.Input;
using Platformer.Service.SceneLoading;
using Zenject;

namespace Platformer.Infrastructure
{
    public class ProjectInstaller : MonoInstaller
    {
        #region Public methods

        public override void InstallBindings()
        {
            StateMachineInstaller.Install(Container);
            SceneLoaderServiceInstaller.Install(Container);
            InputServiceInstaller.Install(Container);
        }

        #endregion
    }
}