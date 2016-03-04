namespace EmpleoDotNet.ViewModel.JobOpportunityLike
{
    public class JobOpportunityLikeParameter
    {
        public int JobOpportunityId { get; set; }

        public bool Like { get; set; }

        public Core.Domain.JobOpportunityLike ToModel()
        {
            return new Core.Domain.JobOpportunityLike
            {
                JobOpportinutyId = JobOpportunityId,
                Like = Like
            };
        }
    }
}