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
    public class MacheteContext : DbContext
    {

        static MacheteContext()
        {
            Database.SetInitializer<MacheteContext>(null);
        }

        public MacheteContext() : base("name=mysqldb")
        {
        }

        public DbSet<User> Users { set; get; }
    }
}
