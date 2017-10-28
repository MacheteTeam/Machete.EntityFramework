using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Machete.EntityFramework.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new MacheteContext())
            {
                User user = new User()
                {
                    Name = "张三"
                };

                db.Users.Add(user);
                db.SaveChanges();
            }

            Console.ReadLine();
        }
    }
}
