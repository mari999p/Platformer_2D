using System;
using UnityEngine;

namespace Platformer.Game.Common
{
    [RequireComponent(typeof(Collider2D))]
    public class TriggerObserver : MonoBehaviour
    {
        #region Events

        public event Action<Collider2D> OnEntered;
        public event Action<Collider2D> OnExited;
        public event Action<Collider2D> OnStayed;

        #endregion
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            OnEntered?.Invoke(other);
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            OnExited?.Invoke(other);
        }

        private void OnTriggerStay2D(Collider2D other)
        {
            OnStayed?.Invoke(other);
        }
    }
}