using System.Data.Entity.Core.Common.CommandTrees;
using System.Data.Entity.Core.Metadata.Edm;
using System.Data.Entity.Infrastructure.Interception;

namespace EmpleoDotNet.Data.Interceptors
{
    public class JobOpportunityIsActiveInterceptor : IDbCommandTreeInterceptor
    {
        public void TreeCreated(DbCommandTreeInterceptionContext interceptionContext)
        {
            if (interceptionContext.OriginalResult.DataSpace != DataSpace.SSpace) return;

            var queryCommand = interceptionContext.Result as DbQueryCommandTree;

            if (queryCommand == null) return;

            var newQuery = queryCommand.Query.Accept(new JobOpportunityIsActiveVisitor());

            interceptionContext.Result = new DbQueryCommandTree(
                queryCommand.MetadataWorkspace,
                queryCommand.DataSpace,
                newQuery);
        }
    }
}