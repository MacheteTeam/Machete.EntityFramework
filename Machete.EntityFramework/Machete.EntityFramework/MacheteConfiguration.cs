using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Machete.EntityFramework.Provider;

namespace Machete.EntityFramework
{
    public class MacheteConfiguration : DbConfiguration
    {

        public MacheteConfiguration()
        {
            var sqlInterceptor = new DbSqlInterceptor().SetSqlHandleProvider(new SqlHandleProvide());

            AddInterceptor(sqlInterceptor);
        }
    }
}
