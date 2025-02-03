using Platformer.Game.Common;
using Platformer.Service.Audio;
using UnityEngine;

namespace Platformer.Game.PickUps
{
    public class PickUps : MonoBehaviour
    {
        #region Variables

        [SerializeField] private AudioClip _collectSound;
        [SerializeField] private AudioService _audioService;

        #endregion

        #region Unity lifecycle

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag(Tag.Player))
            {
                PerformActions(other);
                Destroy(gameObject);
            }
        }

        #endregion

        #region Protected methods

        protected virtual void PerformActions(Collider2D other)
        {
            _audioService.PlaySfx(_collectSound);
        }

        #endregion
    }
}