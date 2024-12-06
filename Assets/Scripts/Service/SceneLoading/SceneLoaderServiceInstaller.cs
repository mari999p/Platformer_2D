using Zenject;

namespace Platformer.Service.SceneLoading
{
    public class SceneLoaderServiceInstaller : Installer<SceneLoaderServiceInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<SceneLoaderService>().AsSingle();
        }
    }
}