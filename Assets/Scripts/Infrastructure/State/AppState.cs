namespace Platformer.Infrastructure.State
{
     public abstract class AppState : State
      {
          #region Public methods
  
          public abstract void Enter();
  
          #endregion
      }
  }