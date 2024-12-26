using Zenject;

namespace Platformer.Service.Mission
{
    public class MissionServiceInstaller : Installer<MissionServiceInstaller>
    {
        #region Public methods

        public override void InstallBindings()
        {
            Container.Bind<MissionService>().FromNewComponentOnNewGameObject().AsSingle();
        }

        #endregion
    }
}