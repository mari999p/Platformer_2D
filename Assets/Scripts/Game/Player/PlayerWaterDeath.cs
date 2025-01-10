using UnityEngine;

namespace Platformer.Game.Player
{
    public class PlayerWaterDeath : MonoBehaviour
    {
        #region Variables

        [SerializeField] private PlayerDeath _playerDeath;

        #endregion

        #region Unity lifecycle

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                _playerDeath = collision.GetComponent<PlayerDeath>();

                if (_playerDeath != null)
                {
                    _playerDeath.Die();
                }
            }
        }

        #endregion
    }
}