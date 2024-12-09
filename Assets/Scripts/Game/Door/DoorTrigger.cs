using System;
using Platformer.Game.Common;
using UnityEngine;

namespace Platformer.Game.Door
{
    [RequireComponent(typeof(Collider2D))]
    public class DoorTrigger : MonoBehaviour
    {
        #region Events

        public event Action OnPlayerEntered;
        public event Action OnPlayerExited;

        #endregion

        #region Unity lifecycle

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag(Tag.Player))
            {
                OnPlayerEntered?.Invoke();
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.CompareTag(Tag.Player))
            {
                OnPlayerExited?.Invoke();
            }
        }

        #endregion
    }
}