namespace Platformer.Infrastructure.State
{
    public abstract class PayloadAppState<T> : State
    {
        #region Public methods

        public abstract void Enter(T payload);

        #endregion
    }
}