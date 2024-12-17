using System;
using UnityEngine;

namespace Platformer.Game.Player.Base
{
    public class PlayerInventory : MonoBehaviour
    {
        #region Variables

        [SerializeField] private int _coins;

        #endregion

        #region Events

        public event Action OnCoinsChanged;

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