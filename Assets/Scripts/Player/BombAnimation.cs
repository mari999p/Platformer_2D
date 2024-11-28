using UnityEngine;

namespace Platformer.Player
{
    public class BombAnimation : MonoBehaviour
    {
        private static readonly int Explosion = Animator.StringToHash("explosion");
        [SerializeField] private Animator _animator;
        
        public void TriggerExplosion()
        {
            _animator.SetTrigger(Explosion);
        }
    }
}