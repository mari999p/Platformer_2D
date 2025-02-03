using System.Collections;
using Platformer.Service.LevelLoading;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Platformer.UI
{
    public class MenuScreen : MonoBehaviour
    {
        #region Variables

        private static readonly int Explode = Animator.StringToHash("Explode");

        [SerializeField] private Button _playButton;
        [SerializeField] private Animator _explosionAnimator;
        [Header("Audio")]
        [SerializeField] private AudioClip _buttonClickSound;
        [SerializeField] private AudioSource _audioSource;

        private bool _buttonClicked;
        private LevelLoadingService _levelLoadingService;

        #endregion

        #region Setup/Teardown

        [Inject]
        public void Construct(LevelLoadingService levelLoadingService)
        {
            _levelLoadingService = levelLoadingService;
        }

        #endregion

        #region Unity lifecycle

        private void Start()
        {
            _playButton.onClick.AddListener(OnPlayButtonClicked);
        }

        #endregion

        #region Private methods

        private void OnPlayButtonClicked()
        {
            if (_buttonClicked)
            {
                return;
            }

            _audioSource.PlayOneShot(_buttonClickSound);
            _explosionAnimator.SetTrigger(Explode);
            _buttonClicked = true;
            StartCoroutine(StartGameAfterAnimation());
        }

        private IEnumerator StartGameAfterAnimation()
        {
            yield return new WaitForSeconds(_explosionAnimator.GetCurrentAnimatorStateInfo(0).length);
            _levelLoadingService.Initialize();
            _levelLoadingService.EnterFirstLevel();
        }

        #endregion
    }
}