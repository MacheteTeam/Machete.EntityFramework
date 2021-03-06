﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Machete.EntityFramework.Handle
{
    /// <summary>
    ///  Sql Trace
    /// </summary>
    public class SqlTraceHandle : ISqlHandle
    {
        public void Execute(string sql)
        {
            Trace.WriteLine(sql);
        }

        public void Execute(Exception exception)
        {
            Trace.WriteLine(exception);
        }
    }
}
