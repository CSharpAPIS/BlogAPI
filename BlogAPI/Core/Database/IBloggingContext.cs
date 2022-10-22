using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogAPI.Core.Database
{
    public interface IBloggingContext : IDisposable
    {
        string GetDbPath();
        string GetDbURL();
    }
}
