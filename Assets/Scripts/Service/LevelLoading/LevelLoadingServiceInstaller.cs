using Zenject;

namespace Platformer.Service.LevelLoading
{
    public class LevelLoadingServiceInstaller : Installer<LevelLoadingServiceInstaller>
    {
        #region Public methods

        public override void InstallBindings()
        {
            Container.Bind<LevelLoadingService>().AsSingle();
        }

        #endregion
    }
}