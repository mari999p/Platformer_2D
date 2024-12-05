using System;
using UnityEngine;

namespace Platformer.Game.Player
{
    public class BombAnimation : MonoBehaviour
    {
        #region Variables

        private static readonly int Explosion = Animator.StringToHash("explosion");
        [SerializeField] private Animator _animator;
        #endregion

        #region Public methods

        public void TriggerExplosion()
        {
            _animator.SetTrigger(Explosion);
        }

        #endregion
    }
}