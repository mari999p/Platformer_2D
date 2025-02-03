using System.Collections;
using Platformer.Game.Enemy.Animation;
using Platformer.Game.Objects.Bomb;
using UnityEngine;

namespace Platformer.Game.Enemy.EnemyAttacks
{
    public class EnemyEatBomb : EnemyBehaviour
    {
        #region Variables

        [Header(nameof(EnemyEatBomb))]
        public bool isEating;
        [SerializeField] private EnemyAnimation _eatAnimation;
        [SerializeField] private LayerMask _bombLayer;
        [SerializeField] private float _eatRadius = 2f;

        [SerializeField] private AudioClip _eatingSound;
        [SerializeField] private AudioSource _audioSource;

        #endregion

        #region Unity lifecycle

        private void Update()
        {
            CheckForBombs();
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(transform.position, _eatRadius);
        }

        #endregion

        #region Private methods

        private void CheckForBombs()
        {
            Collider2D[] bombs = Physics2D.OverlapCircleAll(transform.position, _eatRadius, _bombLayer);
            if (bombs.Length > 0)
            {
                StartEating(bombs[0].GetComponent<Bomb>());
            }
        }

        private void DestroyBomb(Bomb bomb)
        {
            Destroy(bomb.gameObject);
            isEating = false;
        }

        private IEnumerator DestroyBombAfterAnimation(Bomb bomb)
        {
            yield return new WaitForSeconds(0.55f);
            DestroyBomb(bomb);
        }

        private void PlayEatingSound()
        {
            if (_audioSource != null && _eatingSound != null)
            {
                _audioSource.PlayOneShot(_eatingSound);
            }
        }

        private void StartEating(Bomb bomb)
        {
            if (!isEating)
            {
                isEating = true;
                PlayEatingSound();
                _eatAnimation.TriggerSwalowBomb();
                bomb.Defuse();
                StartCoroutine(DestroyBombAfterAnimation(bomb));
            }
        }

        #endregion
    }
}