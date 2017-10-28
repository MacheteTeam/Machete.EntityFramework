using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Machete.EntityFramework.Handle;

namespace Machete.EntityFramework
{
    public class MacheteConfiguration : DbConfiguration
    {

        public MacheteConfiguration(List<ISqlHandle> sqlHandles)
        {
            var sqlInterceptor = new DbSqlInterceptor();
            sqlInterceptor.Handles = sqlHandles;
            AddInterceptor(sqlInterceptor);
        }
    }
}
