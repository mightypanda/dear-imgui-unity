namespace ImGuiNET
{
    using System;

    public abstract class ImGuiScope : IDisposable
    {
        #region Constructors
        ~ImGuiScope()
        {
            Dispose();
        }
        #endregion

        #region Class Methods
        protected abstract void CloseScope();
        #endregion

        #region IDisposable Members
        public void Dispose()
        {
            CloseScope();
        }
        #endregion
    }
}
