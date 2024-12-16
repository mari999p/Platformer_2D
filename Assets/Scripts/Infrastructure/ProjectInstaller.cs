using Platformer.Infrastructure.State;
using Platformer.Service.Input;
using Platformer.Service.Mission;
using Zenject;
// using Platformer.Service.Mission;

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
        }

        #endregion
    }
}