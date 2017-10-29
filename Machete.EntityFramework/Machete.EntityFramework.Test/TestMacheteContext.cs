using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Machete.EntityFramework.Test
{

    //[DbConfigurationType(typeof(MacheteConfiguration))]
    //[DbConfigurationType(typeof(MySql.Data.Entity.MySqlEFConfiguration))]
    public class TestMacheteContext : DbContext
    {
        /// <summary>
        /// if  SetInitializer must set  DbConfiguration 
        /// </summary>
        static TestMacheteContext()
        {
            Database.SetInitializer<TestMacheteContext>(null);
        }

        public DbSet<User> Users { set; get; }

        public TestMacheteContext(string connectionName) : base(connectionName)
        {

        }

        public TestMacheteContext() : base("mysqldb")
        {

        }
    }
}
