using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Machete.EntityFramework.Handle;

namespace Machete.EntityFramework.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            MacheteConfigurationInitializer initializer = new MacheteConfigurationInitializer();
            initializer
                .AddSqlHandle(new SqlTraceHandle())
                .AddSqlHandle(new SqlOutputHandle(@"D:\tmp\output.txt"))
                .SetMacheteConfiguration()
                .AddSubConnection("mysqldb1")
                .AddSubConnection("mysqldb2")
                .SetConnectionConfig();

             TestPartition();
            //Test1();

            Console.ReadLine();
        }

        public static void TestPartition()
        {
            using (TestMacheteContext db = MacheteContextFactory.CreateDbContext<TestMacheteContext>(0))
            {
                User user = new User()
                {
                    Name = "张三300"
                };

                db.Users.Add(user);
                db.SaveChanges();
            }

            using (TestMacheteContext db = MacheteContextFactory.CreateDbContext<TestMacheteContext>(1))
            {
                User user = new User()
                {
                    Name = "张三3"
                };

                db.Users.Add(user);
                db.SaveChanges();
            }
        }

        public static void Test1()
        {
            using (var db = new TestMacheteContext())
            {
                User user = new User()
                {
                    Name = "张三"
                };

                db.Users.Add(user);
                db.SaveChanges();
            }

            using (var db = new TestMacheteContext())
            {
                User user = new User()
                {
                    Name = "张三2"
                };

                db.Users.Add(user);
                db.SaveChanges();
            }
        }
    }
}
