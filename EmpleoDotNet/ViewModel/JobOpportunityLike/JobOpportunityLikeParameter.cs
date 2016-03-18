using JobOpportunityLikeEntity = EmpleoDotNet.Core.Domain.JobOpportunityLike;

namespace EmpleoDotNet.ViewModel.JobOpportunityLike
{
    public class JobOpportunityLikeParameter
    {
        public int JobOpportunityId { get; set; }

        public bool Like { get; set; }

        public JobOpportunityLikeEntity ToModel()
        {
            return new JobOpportunityLikeEntity
            {
                JobOpportunityId = JobOpportunityId,
                Like = Like
            };
        }
    }
}