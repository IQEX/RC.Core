﻿// =====================================//==============================================================//
// License="root\\LICENSE"              //   Copyright © Of Fire Twins Wesp 2015  <ls-micro@ya.ru>      //
// LicenseType="MIT"                    //                  Alise Wesp & Yuuki Wesp                     //
// =====================================//==============================================================//
#if WIN32
namespace RC.Framework.Native.Runtime.Diagnostic
{
    using System;
    /// <summary>
    /// Base class for a <see cref="IDisposable"/> class.
    /// </summary>
    public abstract class DisposeBase : IDisposable
    {
        /// <summary>
        /// Occurs when this instance is starting to be disposed.
        /// </summary>
        public event EventHandler<EventArgs> Disposing;

        /// <summary>
        /// Occurs when this instance is fully disposed.
        /// </summary>
        public event EventHandler<EventArgs> Disposed;

        /// <summary>
        /// Releases unmanaged resources and performs other cleanup operations before the
        /// <see cref="DisposeBase"/> is reclaimed by garbage collection.
        /// </summary>
        ~DisposeBase()
        {
            // Finalizer calls Dispose(false)
            CheckAndDispose(disposing: false);
        }

        /// <summary>
        /// Gets a value indicating whether this instance is disposed.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance is disposed; otherwise, <c>false</c>.
        /// </value>
        public bool IsDisposed { get; private set; }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            CheckAndDispose(disposing: true);
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        private void CheckAndDispose(bool disposing)
        {
            // TODO Should we throw an exception if this method is called more than once?
            if (!IsDisposed)
            {
                EventHandler<EventArgs> disposingHandlers = Disposing;
                if (disposingHandlers != null)
                    disposingHandlers(this, DisposeEventArgs.Get(disposing));

                Dispose(disposing);
                GC.SuppressFinalize(this);

                IsDisposed = true;

                EventHandler<EventArgs> disposedHandlers = Disposed;
                if (disposedHandlers != null)
                    disposedHandlers(this, DisposeEventArgs.Get(disposing));
            }
        }

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources
        /// </summary>
        /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        protected abstract void Dispose(bool disposing);
    }
}
#endif