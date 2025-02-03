using Platformer.Game.Common;
using UnityEngine;

namespace Platformer.Game.Objects
{
    public class Spikes : MonoBehaviour
    {
        #region Variables

        [SerializeField] private int _damage = 1;
        [SerializeField] private LayerMask _playerLayer;

        [Header("Audio")]
        [SerializeField] private AudioClip _spikeSound;
        [SerializeField] private AudioSource _audioSource;

        #endregion

        #region Unity lifecycle

        private void Awake()
        {
            _audioSource = gameObject.AddComponent<AudioSource>();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (((1 << collision.gameObject.layer) & _playerLayer) != 0)
            {
                UnitHp playerHp = collision.GetComponent<UnitHp>();
                if (playerHp != null)
                {
                    playerHp.Change(-_damage);

                    AudioSpikes();
                }
            }
        }

        #endregion

        #region Private methods

        private void AudioSpikes()
        {
            if (_spikeSound != null && _audioSource != null)
            {
                _audioSource.PlayOneShot(_spikeSound);
            }
        }

        #endregion
    }
}