using Platformer.Game.Player;
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
        private Vector2 _playerInitialOffset;

        #endregion

        #region Unity lifecycle

        private void Start()
        {
            _playerMovement = FindObjectOfType<PlayerMovement>();
        }

        private void Update()
        {
            if (_playerMovement != null && IsPlayerOnShip())
            {
                MaintainPlayerPosition();
                MoveShip();
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

        #region Private methods

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

        private void MoveShip()
        {
            transform.Translate(Vector2.right * _shipSpeed * Time.deltaTime);
        }

        #endregion
    }
}