using Platformer.Game.Utils.Log;
using Unity.VisualScripting;
using Zenject;

namespace Platformer.Infrastructure
{
    public class ProjectInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            this.Error();
        }
    }
}