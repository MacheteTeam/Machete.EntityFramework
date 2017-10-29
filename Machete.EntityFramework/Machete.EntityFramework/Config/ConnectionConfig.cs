using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Machete.EntityFramework.Config
{
    public class ConnectionConfig
    {
        public static Dictionary<int, String> Sub = new Dictionary<int, string>();

        public static Func<int, int> PartitionStrategyFunc = null;
    }
}
