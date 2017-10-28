using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Machete.EntityFramework.Handle;

namespace Machete.EntityFramework
{
    public class MacheteConfigurationInitializer
    {
        public List<ISqlHandle> SqlHandles = new List<ISqlHandle>();

        public MacheteConfigurationInitializer BuildInitializer()
        {
            return new MacheteConfigurationInitializer();
        }

        public MacheteConfigurationInitializer AddSqlHandel(ISqlHandle sqlHandle)
        {
            SqlHandles.Add(sqlHandle);
            return this;
        }


        public void SetMacheteConfiguration()
        {
            DbConfiguration.SetConfiguration(new MacheteConfiguration(SqlHandles));
        }
    }
}
