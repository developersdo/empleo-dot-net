using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmpleoDotNet.Core.Domain;
using EmpleoDotNet.Repository;
using EmpleoDotNet.Repository.Contracts;

namespace EmpleoDotNet.AppServices
{
    public class JobOpportunityLikeService : IJobOpportunityLikeService
    {
        private readonly IJobOpportunityLikeRepository _jobOpportunityLikeRepository;

        public JobOpportunityLikeService(IJobOpportunityLikeRepository jobOpportunityLikeRepository)
        {
            _jobOpportunityLikeRepository = jobOpportunityLikeRepository;
        }

        public void CreateNewLike(JobOpportunityLike jopOpportunityLike)
        {
            _jobOpportunityLikeRepository.Add(jopOpportunityLike);
            _jobOpportunityLikeRepository.SaveChanges();
        }

        public List<JobOpportunityLike> GetByJobOpportunityId(int jobOpportunityId)
        {
            return _jobOpportunityLikeRepository.GetByJobOpportunityId(jobOpportunityId);
        }
    }
}
