using Platformer.Game.Player;
using Platformer.Service.Input;
using Platformer.Service.Restart;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Platformer.UI
{
    public class GameOverScreen : MonoBehaviour
    {
        #region Variables

        [SerializeField] private GameObject _gameOverPanel;
        [SerializeField] private Button _retryButton;
        [SerializeField] private TMP_Text _scoreText;
        [SerializeField] private PlayerInventory _playerInventory;
        private IInputService _inputService;
        private IRestartService _restartService;

        #endregion

        #region Setup/Teardown

        [Inject]
        public void Construct(IRestartService restartService, IInputService inputService)
        {
            _restartService = restartService;
            _inputService = inputService;
        }

        #endregion

        #region Unity lifecycle

        private void OnEnable()
        {
            _gameOverPanel.SetActive(false);
            _retryButton.onClick.AddListener(RetryLevel);
        }

        private void OnDisable()
        {
            _retryButton.onClick.RemoveListener(RetryLevel);
        }

        #endregion

        #region Public methods

        public void ShowGameOver()
        {
            _gameOverPanel.SetActive(true);
            _inputService.Dispose();
            Time.timeScale = 0;
            UpdateScoreText();
        }

        #endregion

        #region Private methods

        private void RetryLevel()
        {
            Time.timeScale = 1;
            _restartService.RestartCurrentScene();
            _inputService.Initialize();
        }

        private void UpdateScoreText()
        {
            int coinsCollected = _playerInventory.GetCoins();
            _scoreText.text = $"Score:{coinsCollected}";
        }

        #endregion
    }
}