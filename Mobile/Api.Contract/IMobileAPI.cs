using System.Collections.Generic;

namespace Api.Contract
{
    public interface IMobileAPI
    {
        IList<JobDto> GetJobs();
    }

    public class JobDto
    {
    }
}