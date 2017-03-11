using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concours
{
    public class DisposableObj : IDisposable
    {
        public bool wasDisposedMoreThanOnce { get; internal set; } = false;
        public bool isDisposed { get; internal set; } = false;

        public void Dispose()
        {
            this.wasDisposedMoreThanOnce = this.isDisposed;
            this.isDisposed = true;
        }
    }
}
