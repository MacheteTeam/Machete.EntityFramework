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
            initializer.AddSqlHandel(new SqlTraceHandle())
                .AddSqlHandel(new SqlOutputHandle(@"D:\tmp\output.txt"))
                .SetMacheteConfiguration();

            using (var db = new MacheteContext())
            {
                User user = new User()
                {
                    Name = "张三"
                };

                db.Users.Add(user);
                db.SaveChanges();
            }

            using (var db = new MacheteContext())
            {
                User user = new User()
                {
                    Name = "张三2"
                };

                db.Users.Add(user);
                db.SaveChanges();
            }

            Console.ReadLine();
        }
    }
}
