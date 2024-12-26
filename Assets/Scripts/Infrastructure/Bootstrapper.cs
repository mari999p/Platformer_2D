using Platformer.Infrastructure.State;
using UnityEngine;
using Zenject;

namespace Platformer.Infrastructure
{
    public class Bootstrapper : MonoBehaviour
    {
        #region Variables

        private StateMachine _stateMachine;

        #endregion

        #region Setup/Teardown

        [Inject]
        public void Construct(StateMachine stateMachine)
        {
            _stateMachine = stateMachine;
        }

        #endregion

        #region Unity lifecycle

        private void Awake()
        {
            _stateMachine.Enter<BootstrapState>();
        }

        #endregion
    }
}