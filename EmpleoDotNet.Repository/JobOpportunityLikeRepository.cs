using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmpleoDotNet.Core.Domain;
using EmpleoDotNet.Data;
using EmpleoDotNet.Repository.Contracts;

namespace EmpleoDotNet.Repository
{
    public class JobOpportunityLikeRepository : BaseRepository<JobOpportunityLike>, IJobOpportunityLikeRepository
    {
        public JobOpportunityLikeRepository(EmpleadoContext context) : base(context)
        {
        }

        public List<JobOpportunityLike> GetLikesByJobOpportunityId(int jobOpportunityId)
        {
            return DbSet.Where(x => x.JobOpportunityId == jobOpportunityId).ToList();
        }
    }
}
