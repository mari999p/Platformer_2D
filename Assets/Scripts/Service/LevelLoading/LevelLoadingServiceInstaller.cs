using Zenject;

namespace Platformer.Service.LevelLoading
{
    public class LevelLoadingServiceInstaller: Installer<LevelLoadingServiceInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<LevelLoadingService>().AsSingle();
        }
    }
}