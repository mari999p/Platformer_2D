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

        [SerializeField] private Button _playButton;
        [SerializeField] private Animator _explosionAnimator;
        private LevelLoadingService _levelLoadingService;
        private bool _buttonClicked = false;
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
                return;
            _explosionAnimator.SetTrigger("Explode");
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