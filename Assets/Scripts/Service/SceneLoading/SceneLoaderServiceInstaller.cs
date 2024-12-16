using Zenject;

namespace Platformer.Service.SceneLoading
{
    public class SceneLoaderServiceInstaller : Installer<SceneLoaderServiceInstaller>
    {
        #region Public methods

        public override void InstallBindings()
        {
            Container.Bind<SceneLoaderService>().AsSingle();
        }

        #endregion
    }
}