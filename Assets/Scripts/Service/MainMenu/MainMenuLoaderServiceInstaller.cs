using Zenject;

namespace Platformer.Service.MainMenu
{
    public class MainMenuLoaderServiceInstaller : Installer<MainMenuLoaderServiceInstaller>
    {
        #region Public methods

        public override void InstallBindings()
        {
            Container.Bind<MainMenuLoaderService>().AsSingle();
        }

        #endregion
    }
}