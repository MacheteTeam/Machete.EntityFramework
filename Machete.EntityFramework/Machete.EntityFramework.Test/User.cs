using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Machete.EntityFramework.Test
{
    [Table("user")]
    public class User
    {
        [Column("id")]
        public int Id { set; get; }

        [Column("username")]
        public string Name { set; get; }
    }
}
