using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Machete.EntityFramework.Config;
using Machete.EntityFramework.Handle;

namespace Machete.EntityFramework
{
    public class MacheteConfigurationInitializer
    {

        public List<string> SubConnectionNameList = new List<string>();

        public List<ISqlHandle> SqlHandles = new List<ISqlHandle>();

        public MacheteConfigurationInitializer BuildInitializer()
        {
            return new MacheteConfigurationInitializer();
        }

        public MacheteConfigurationInitializer AddSqlHandle(ISqlHandle sqlHandle)
        {
            SqlHandles.Add(sqlHandle);
            return this;
        }


        public MacheteConfigurationInitializer AddSubConnection(string connectionName)
        {
            SubConnectionNameList.Add(connectionName);
            return this;
        }

        public MacheteConfigurationInitializer SetMacheteConfiguration()
        {
            DbConfiguration.SetConfiguration(new MacheteConfiguration(SqlHandles));
            return this;
        }

        public MacheteConfigurationInitializer SetConnectionConfig()
        {
            for (int i = 0; i < SubConnectionNameList.Count; i++)
            {
                ConnectionConfig.Sub.Add(i + 1, SubConnectionNameList[i]);
            }
            return this;
        }

    }

}
