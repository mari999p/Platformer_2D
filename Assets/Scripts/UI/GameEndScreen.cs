using Platformer.Game.Player;
using Platformer.Service.MainMenu;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Platformer.UI
{
    public class GameEndScreen : MonoBehaviour
    {
        #region Variables

        [SerializeField] private Button _mainMenuButton;
        [SerializeField] private TMP_Text _coinsCollectedText;
        [SerializeField] private PlayerInventory _playerInventory;

        [Header("Audio")]
        [SerializeField] private AudioClip _buttonClickSound;
        [SerializeField] private AudioSource _audioSource;
        private MainMenuLoaderService _mainMenuLoaderService;

        #endregion

        #region Setup/Teardown

        [Inject]
        public void Construct(MainMenuLoaderService mainMenuLoaderService)
        {
            _mainMenuLoaderService = mainMenuLoaderService;
        }

        #endregion

        #region Unity lifecycle

        private void Awake()
        {
            _mainMenuButton.onClick.AddListener(OnMainMenuButtonClicked);
        }

        #endregion

        #region Public methods

        public void ShowGameEnd()
        {
            DisableAllAudioSources();
            gameObject.SetActive(true);
            if (_coinsCollectedText != null)
            {
                int coinsCollected = _playerInventory.GetCoins();
                _coinsCollectedText.text = $"Coins Collected: {coinsCollected}";
            }
        }

        #endregion

        #region Private methods

        private void DisableAllAudioSources()
        {
            AudioSource[] audioSources = FindObjectsOfType<AudioSource>();
            foreach (AudioSource audioSource in audioSources)
            {
                audioSource.enabled = false;
            }
        }

        private void OnMainMenuButtonClicked()
        {
            PlayButtonClickSound();
            _mainMenuLoaderService.LoadMainMenu();
        }

        private void PlayButtonClickSound()
        {
            if (_buttonClickSound != null && _audioSource != null)
            {
                _audioSource.PlayOneShot(_buttonClickSound);
            }
        }

        #endregion
    }
}