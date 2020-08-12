namespace ImGuiNET
{
    using System;

    public abstract class ImGuiScope : IDisposable
    {
        #region Fields
        protected bool returnValue;
        #endregion

        #region Properties
        public bool ReturnValue
        {
            get { return returnValue; }
        }
        #endregion

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
