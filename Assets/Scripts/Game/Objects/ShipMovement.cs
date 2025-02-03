using System.Collections;
using Platformer.Game.Player;
using Platformer.UI;
using UnityEngine;

namespace Platformer.Game.Objects
{
    public class ShipMovement : MonoBehaviour
    {
        #region Variables

        [Header("Ship Settings")]
        [SerializeField] private float _shipSpeed = 5f;
        [SerializeField] private PlayerMovement _playerMovement;
        [SerializeField] private Collider2D _shipCollider;
        [SerializeField] private GameEndScreen _gameEndScreen;

        [Header("Game End Settings")]
        [SerializeField] private Vector3 _gameEndPosition;
        [SerializeField] private float _endGameDelay = 2f;
        private Vector2 _playerInitialOffset;

        #endregion

        #region Unity lifecycle

        private void Start()
        {
            _playerMovement = FindObjectOfType<PlayerMovement>();
            if (_gameEndScreen != null)
            {
                _gameEndScreen.gameObject.SetActive(false);
            }
        }

        private void Update()
        {
            if (_playerMovement != null && IsPlayerOnShip())
            {
                MaintainPlayerPosition();
                MoveShip();
                if (HasReachedEndPosition())
                {
                    EndGame();
                }
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.gameObject == _playerMovement.gameObject)
            {
                _playerInitialOffset = Vector2.zero;
            }
        }

        #endregion

        #region Public methods

        public void MoveShip()
        {
            transform.Translate(Vector2.right * _shipSpeed * Time.deltaTime);
        }

        #endregion

        #region Private methods

        private void DeactivateObjects()
        {
            Destroy(_playerMovement.gameObject);
            Destroy(gameObject);
        }

        private void EndGame()
        {
            StartCoroutine(ShowGameEndAfterDelay());
        }

        private bool HasReachedEndPosition()
        {
            return transform.position.x >= _gameEndPosition.x;
        }

        private bool IsPlayerOnShip()
        {
            if (_playerMovement != null && _shipCollider != null)
            {
                return _shipCollider.IsTouching(_playerMovement.GetComponent<Collider2D>());
            }

            return false;
        }

        private void MaintainPlayerPosition()
        {
            if (_playerInitialOffset == Vector2.zero)
            {
                _playerInitialOffset = _playerMovement.transform.position - transform.position;
            }

            _playerMovement.transform.position = transform.position + (Vector3)_playerInitialOffset;
        }

        private IEnumerator ShowGameEndAfterDelay()
        {
            yield return new WaitForSeconds(_endGameDelay);
            _gameEndScreen.ShowGameEnd();
            DeactivateObjects();
        }

        #endregion
    }
}