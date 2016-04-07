using System.Collections.Generic;
using EmpleoDotNet.Core.Domain;

namespace EmpleoDotNet.Repository.Contracts
{
    public interface IJobOpportunityLikeRepository : IBaseRepository<JobOpportunityLike>
    {
        List<JobOpportunityLike> GetLikesByJobOpportunityId(int jobOpportunityId);
    }
}