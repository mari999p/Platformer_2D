using UnityEngine;

namespace Platformer.Game.Player
{
    public class BombAnimation : MonoBehaviour
    {
        #region Variables

        private static readonly int Defuse = Animator.StringToHash("defuse");

        private static readonly int Explosion = Animator.StringToHash("explosion");
        private static readonly int Ignition = Animator.StringToHash("ignite");
        [SerializeField] private Animator _animator;

        #endregion

        #region Public methods

        public void TriggerDefuse()
        {
            _animator.SetTrigger(Defuse);
        }

        public void TriggerExplosion()
        {
            _animator.SetTrigger(Explosion);
        }

        public void TriggerIgnite()
        {
            _animator.SetTrigger(Ignition);
        }

        #endregion
    }
}