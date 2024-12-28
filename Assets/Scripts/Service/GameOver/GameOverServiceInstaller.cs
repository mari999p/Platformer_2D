using Zenject;

namespace Platformer.Service.GameOver
{
    public class GameOverServiceInstaller : Installer<GameOverServiceInstaller>
    {
        #region Public methods

        public override void InstallBindings()
        {
            Container.Bind<GameOverService>().ToSelf().AsTransient();
        }

        #endregion
    }
}