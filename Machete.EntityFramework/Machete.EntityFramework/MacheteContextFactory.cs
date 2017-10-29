using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Machete.EntityFramework.Config;

namespace Machete.EntityFramework
{
    public class MacheteContextFactory
    {
        static MacheteContextFactory()
        {

        }

        public static T CreateDbContext<T>(int partitionSeed) where T : DbContext, new()
        {
            string connectionName;
            ConnectionConfig.Sub.TryGetValue(ComputePartition(partitionSeed), out connectionName);
            if (string.IsNullOrEmpty(connectionName))
            {
                throw new Exception("no connectionName");
            }
            T context = Activator.CreateInstance(typeof(T), connectionName) as T;
            return context;
        }

        protected static int ComputePartition(int partitionSeed)
        {
            int id = partitionSeed % ConnectionConfig.Sub.Count + 1;
            return id;
        }
    }
}
