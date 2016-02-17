using System.Data.Entity.Core.Common.CommandTrees;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Data.Entity.Core.Metadata.Edm;
using System.Linq;

namespace EmpleoDotNet.Data.Interceptors
{
    public class JobOpportunityIsActiveVisitor : DefaultExpressionVisitor
    {
        public override DbExpression Visit(DbScanExpression expression)
        {
            const string column = "IsActive";

            var table = (EntityType)expression.Target.ElementType;

            if (!table.Properties.Any(p => p.Name == column))
                return base.Visit(expression);

            var binding = expression.Bind();

            return
                binding.Filter(
                    binding.VariableType.Variable(binding.VariableName)
                        .Property(column)
                        .Equal(DbExpression.FromBoolean(true)));
        }
    }
}