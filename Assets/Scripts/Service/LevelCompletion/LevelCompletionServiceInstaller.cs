using Zenject;

namespace Platformer.Service.LevelCompletion
{
    public class LevelCompletionServiceInstaller : Installer<LevelCompletionServiceInstaller>
    {
        #region Public methods

        public override void InstallBindings()
        {
            Container.Bind<LevelCompletionService>().AsSingle();
        }

        #endregion
    }
}