using System;
using UnityEngine;

namespace Platformer.Game.Player
{
    public class PlayerInventory : MonoBehaviour
    {
        #region Variables

        private static  int _coins;
    
        #endregion

        #region Events

        public event Action OnCoinsChanged;

        #endregion

        #region Public methods
        private void Awake()
        {
            OnCoinsChanged?.Invoke();
        }
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