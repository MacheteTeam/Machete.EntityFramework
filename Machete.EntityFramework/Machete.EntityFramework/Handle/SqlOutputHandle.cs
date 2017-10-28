using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Machete.EntityFramework.Handle
{
    public class SqlOutputHandle : ISqlHandle
    {
        public string Path = AppDomain.CurrentDomain.BaseDirectory + "/output.txt";

        public string NewLine = Environment.NewLine;

        public SqlOutputHandle(string path)
        {
            Path = path;
        }

        public SqlOutputHandle()
        {

        }

        public void Execute(string sql)
        {
            if (File.Exists(Path))
            {
                File.WriteAllLines(Path, new string[] { sql });
            }
            File.AppendAllLines(Path, new string[] { sql });
        }

        public void Execute(Exception exception)
        {
            if (File.Exists(Path))
            {
                File.WriteAllLines(Path, new string[] { exception.StackTrace });
            }
            File.AppendAllLines(Path, new string[] { exception.StackTrace });
        }
    }
}
