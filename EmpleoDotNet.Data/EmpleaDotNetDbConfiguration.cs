using System.Data.Entity;
using EmpleoDotNet.Data.Interceptors;

namespace EmpleoDotNet.Data
{
    public class EmpleaDotNetDbConfiguration : DbConfiguration
    {
        public EmpleaDotNetDbConfiguration()
        {
            AddInterceptor(new JobOpportunityIsActiveInterceptor());
        }
    }
}