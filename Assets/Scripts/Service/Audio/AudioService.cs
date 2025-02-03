using UnityEngine;

namespace Platformer.Service.Audio
{
    public class AudioService : MonoBehaviour
    {
        #region Variables

        [SerializeField] private AudioSource _sfxAudioSource;

        #endregion

        #region Public methods

        public void PlaySfx(AudioClip clip)
        {
            if (clip == null)
            {
                return;
            }

            _sfxAudioSource.PlayOneShot(clip);
        }

        #endregion
    }
}