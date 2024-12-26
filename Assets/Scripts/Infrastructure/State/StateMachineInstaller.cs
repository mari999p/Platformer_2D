using Zenject;

namespace Platformer.Infrastructure.State
{
    public class StateMachineInstaller : Installer<StateMachineInstaller>
    {
        #region Public methods

        public override void InstallBindings()
        {
            Container.Bind<StateMachine>().AsSingle();
            Container.Bind<StateFactory>().AsSingle();
        }

        #endregion
    }
}