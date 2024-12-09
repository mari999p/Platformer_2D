using System.Collections;
using Platformer.Game.Player.Base;
using UnityEngine;

namespace Platformer.Game.Door
{
    public class DoorControl : MonoBehaviour
    {
        #region Variables

        [SerializeField] private Transform _exitDoor;
        [SerializeField] private Transform _entryDoor;
        [SerializeField] private DoorAnimation _doorAnimation;
        [SerializeField] private DoorTrigger _doorTrigger;
        [SerializeField] private GameObject _player;
        [SerializeField] private PlayerAnimation _playerAnimation;
        private bool _isPlayerInTrigger;

        #endregion

        #region Unity lifecycle

        private void Update()
        {
            if (_isPlayerInTrigger && Input.GetKeyDown(KeyCode.E))
            {
                TryEnterDoor();
            }
        }

        private void OnEnable()
        {
            _doorTrigger.OnPlayerEntered += HandlePlayerEntered;
            _doorTrigger.OnPlayerExited += HandlePlayerExited;
        }

        private void OnDisable()
        {
            _doorTrigger.OnPlayerEntered -= HandlePlayerEntered;
            _doorTrigger.OnPlayerExited -= HandlePlayerExited;
        }

        #endregion

        #region Private methods

        private void HandlePlayerEntered()
        {
            _isPlayerInTrigger = true;
        }

        private void HandlePlayerExited()
        {
            _isPlayerInTrigger = false;
            _doorAnimation.CloseDoor();
        }

        private IEnumerator TeleportPlayer()
        {
            yield return new WaitForSeconds(1f);
            _player.transform.position = _exitDoor.position;
            _playerAnimation.TriggerExitDoor();
        }

        private void TryEnterDoor()
        {
            _doorAnimation.OpenDoor();
            _playerAnimation?.TriggerEnterDoor();
            StartCoroutine(TeleportPlayer());
        }

        #endregion
    }
}