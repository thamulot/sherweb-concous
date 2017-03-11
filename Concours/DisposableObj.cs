using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concours
{
    public class DisposableObj : IDisposable
    {
        public bool isDisposed { get; internal set; } = false;

        public void Dispose()
        {
            this.isDisposed = true;
        }
    }
}
