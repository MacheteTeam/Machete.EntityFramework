using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity.Infrastructure.Interception;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Machete.EntityFramework.Provider;

namespace Machete.EntityFramework
{
    /// <summary>
    ///  拦截获取sql语句
    /// </summary>
    class DbSqlInterceptor : DbCommandInterceptor
    {

        public DbSqlInterceptor SetSqlHandleProvider(ISqlHandleProvider sqlHandleProvider)
        {
            this.SqlHandleProvider = sqlHandleProvider;
            return this;
        }

        public ISqlHandleProvider SqlHandleProvider;

        public override void NonQueryExecuting(DbCommand command, DbCommandInterceptionContext<int> interceptionContext)
        {
            base.NonQueryExecuting(command, interceptionContext);
        }

        public override void NonQueryExecuted(DbCommand command, DbCommandInterceptionContext<int> interceptionContext)
        {
            if (interceptionContext.Exception != null)
                SqlHandleProvider.Execute(interceptionContext.Exception);
            else
                SqlHandleProvider.Execute(command.CommandText);
            base.NonQueryExecuted(command, interceptionContext);
        }

        public override void ReaderExecuting(DbCommand command, DbCommandInterceptionContext<DbDataReader> interceptionContext)
        {
            base.ReaderExecuting(command, interceptionContext);
        }

        public override void ReaderExecuted(DbCommand command, DbCommandInterceptionContext<DbDataReader> interceptionContext)
        {
            if (interceptionContext.Exception != null)
                SqlHandleProvider.Execute(interceptionContext.Exception);
            else
                SqlHandleProvider.Execute(command.CommandText);
            base.ReaderExecuted(command, interceptionContext);
        }

        public override void ScalarExecuting(DbCommand command, DbCommandInterceptionContext<object> interceptionContext)
        {

            base.ScalarExecuting(command, interceptionContext);
        }

        public override void ScalarExecuted(DbCommand command, DbCommandInterceptionContext<object> interceptionContext)
        {
            if (interceptionContext.Exception != null)
                SqlHandleProvider.Execute(interceptionContext.Exception);
            else
                SqlHandleProvider.Execute(command.CommandText);
            base.ScalarExecuted(command, interceptionContext);
        }
    }
}
