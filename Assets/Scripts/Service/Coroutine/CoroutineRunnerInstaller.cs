using Zenject;

namespace Platformer.Service.Coroutine
{
    public class CoroutineRunnerInstaller : Installer<CoroutineRunnerInstaller>
    {
        #region Public methods

        public override void InstallBindings()
        {
            Container.Bind<CoroutineRunner>().FromNewComponentOnNewGameObject().AsSingle();
        }

        #endregion
    }
}