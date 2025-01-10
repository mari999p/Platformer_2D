using Platformer.Game.Common;
using UnityEngine;

namespace Platformer.Game.Objects
{
    public class Spikes: MonoBehaviour
    {
        [SerializeField] private int _damage = 1;
        [SerializeField] private LayerMask _playerLayer;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (((1 << collision.gameObject.layer) & _playerLayer) != 0)
            {
                UnitHp playerHp = collision.GetComponent<UnitHp>();
                if (playerHp != null)
                {
                    playerHp.Change(-_damage);
                }
            }
        }
    }
}