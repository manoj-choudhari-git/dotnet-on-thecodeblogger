using System;
using System.Data.Common;
using System.Threading;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore.Diagnostics;

namespace EFCoreInterceptorsDemo.Data.EF
{
    public class DemoDbCommandInterceptor : DbCommandInterceptor
    {
        public override InterceptionResult<DbDataReader> ReaderExecuting(
            DbCommand command,
            CommandEventData eventData,
            InterceptionResult<DbDataReader> result)
        {
            ModifyCommand(command);

            return result;
        }

        public override ValueTask<InterceptionResult<DbDataReader>> ReaderExecutingAsync(
            DbCommand command,
            CommandEventData eventData,
            InterceptionResult<DbDataReader> result,
            CancellationToken cancellationToken = default)
        {
            ModifyCommand(command);

            return new ValueTask<InterceptionResult<DbDataReader>>(result);
        }

        private static void ModifyCommand(DbCommand command)
        {
            if (command.CommandText.StartsWith("-- Apply OrderBy DESC", StringComparison.Ordinal))
            {
                Console.WriteLine("DemoDbCommandInterceptor: Applying OrderBy DESC");
                command.CommandText += " Order By 1 DESC";
            }
        }
    }
}
