using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity.Infrastructure.Interception;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Machete.EntityFramework.Handle;

namespace Machete.EntityFramework
{
    /// <summary>
    ///  拦截获取sql语句
    /// </summary>
    class DbSqlInterceptor : DbCommandInterceptor
    {

        public List<ISqlHandle> Handles = new List<ISqlHandle>();

        public void AddSqlHandle(ISqlHandle sqlHandle)
        {
            Handles.Add(sqlHandle);
        }

        public override void NonQueryExecuting(DbCommand command, DbCommandInterceptionContext<int> interceptionContext)
        {
            base.NonQueryExecuting(command, interceptionContext);
        }

        public override void NonQueryExecuted(DbCommand command, DbCommandInterceptionContext<int> interceptionContext)
        {
            if (interceptionContext.Exception != null)
                ExecuteException(interceptionContext.Exception);
            else
                ExecuteSql(command.CommandText);
            base.NonQueryExecuted(command, interceptionContext);
        }

        public override void ReaderExecuting(DbCommand command, DbCommandInterceptionContext<DbDataReader> interceptionContext)
        {
            base.ReaderExecuting(command, interceptionContext);
        }

        public override void ReaderExecuted(DbCommand command, DbCommandInterceptionContext<DbDataReader> interceptionContext)
        {
            if (interceptionContext.Exception != null)
                ExecuteException(interceptionContext.Exception);
            else
                ExecuteSql(command.CommandText);
            base.ReaderExecuted(command, interceptionContext);
        }

        public override void ScalarExecuting(DbCommand command, DbCommandInterceptionContext<object> interceptionContext)
        {

            base.ScalarExecuting(command, interceptionContext);
        }

        public override void ScalarExecuted(DbCommand command, DbCommandInterceptionContext<object> interceptionContext)
        {
            if (interceptionContext.Exception != null)
                ExecuteException(interceptionContext.Exception);
            else
                ExecuteSql(command.CommandText);
            base.ScalarExecuted(command, interceptionContext);
        }


        protected void ExecuteSql(string sql)
        {
            foreach (var handle in Handles)
            {
                handle.Execute(sql);
            }
        }

        protected void ExecuteException(Exception exception)
        {
            foreach (var handle in Handles)
            {
                handle.Execute(exception);
            }
        }
    }
}
