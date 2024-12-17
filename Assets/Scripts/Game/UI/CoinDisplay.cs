using Platformer.Game.Player.Base;
using TMPro;
using UnityEngine;

namespace Platformer.Game.UI
{
    public class CoinDisplay : MonoBehaviour
    {
        #region Variables

        [Header("UI")]
        [SerializeField] private TMP_Text _goldText;
        [SerializeField] private PlayerInventory _playerInventory;

        #endregion

        #region Unity lifecycle

        private void Start()
        {
            UpdateCoinText();
        }

        private void OnEnable()
        {
            _playerInventory.OnCoinsChanged += UpdateCoinText;
        }

        private void OnDisable()
        {
            _playerInventory.OnCoinsChanged -= UpdateCoinText;
        }

        #endregion

        #region Private methods

        private void UpdateCoinText()
        {
            _goldText.text = $"Coins: {_playerInventory.GetCoins()}";
        }

        #endregion
    }
}