using System;
using UnityEngine;

namespace Platformer.Game.Common
{
    public class UnitHp : MonoBehaviour, IDamageable
    {
        #region Variables

        [SerializeField] private int _start = 10;
        [SerializeField] private int _max = 10;
        [SerializeField] private int _current;

        #endregion

        #region Events

        public event Action<int> OnChanged;
        public int Current => _current;
        public int Max => _max;

        #endregion

        #region Unity lifecycle

        private void Awake()
        {
            _current = _start;
        }

        #endregion

        #region IDamageable

        public void ApplyDamage(int damage)
        {
            Change(-damage);
        }

        #endregion

        #region Public methods

        public void Change(int value)
        {
            int newValue = Mathf.Clamp(_current + value, 0, _max);
            bool needNotify = newValue != _current;
            _current = newValue;

            if (needNotify)
            {
                OnChanged?.Invoke(_current);
            }
        }

        #endregion
    }
}