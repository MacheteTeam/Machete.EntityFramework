using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Machete.EntityFramework.Provider
{
    public interface ISqlHandleProvider
    {
        void Execute(string sql);

        void Execute(Exception exception);
    }
}
