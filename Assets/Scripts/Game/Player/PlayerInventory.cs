using System;
using UnityEngine;

namespace Platformer.Game.Player
{
    public class PlayerInventory : MonoBehaviour
    {
        #region Variables

        private static int _coins;

        #endregion

        #region Events

        public event Action OnCoinsChanged;

        #endregion

        #region Unity lifecycle

        private void Awake()
        {
            OnCoinsChanged?.Invoke();
        }

        #endregion

        #region Public methods

        public void AddCoins(int amount)
        {
            _coins += amount;
            OnCoinsChanged?.Invoke();
        }

        public int GetCoins()
        {
            return _coins;
        }

        #endregion
    }
}