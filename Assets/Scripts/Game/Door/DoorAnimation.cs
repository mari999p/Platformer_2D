using UnityEngine;

namespace Platformer.Game.Door
{
    [RequireComponent(typeof(Animator))]
    public class DoorAnimation : MonoBehaviour
    {
        #region Variables

        private static readonly int Close = Animator.StringToHash("close");

        private static readonly int Open = Animator.StringToHash("open");
        [SerializeField] private Animator _animator;

        #endregion

        #region Unity lifecycle

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        #endregion

        #region Public methods

        public void CloseDoor()
        {
            _animator.SetTrigger(Close);
        }

        public void OpenDoor()
        {
            _animator.SetTrigger(Open);
        }

        #endregion
    }
}