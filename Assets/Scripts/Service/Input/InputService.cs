using System;
using UnityEngine;

namespace Platformer.Service.Input
{
    public interface IInputService
    {
        #region Events

        event Action OnAttacked;
        event Action OnJump;

        #endregion

        #region Properties

        Vector2 MoveDirection { get; }

        #endregion

        #region Public methods

        void Dispose();

        void Initialize(Camera mainCamera, Transform playerTransform);

        #endregion
    }
}