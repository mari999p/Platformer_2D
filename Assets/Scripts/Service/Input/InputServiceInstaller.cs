using Zenject;

namespace Platformer.Service.Input
{
    public class InputServiceInstaller : Installer<InputServiceInstaller>
    {
        #region Public methods

        public override void InstallBindings()
        {
            Container.Bind<IInputService>().To<PCInputService>().FromNewComponentOnNewGameObject().AsSingle();
        }

        #endregion
    }
}