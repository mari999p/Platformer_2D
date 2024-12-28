using Zenject;

namespace Platformer.Service.Restart
{
    public class RestartServiceInstaller : Installer<RestartServiceInstaller>
    {
        #region Public methods

        public override void InstallBindings()
        {
            Container.Bind<IRestartService>().To<RestartService>().AsSingle();
        }

        #endregion
    }
}