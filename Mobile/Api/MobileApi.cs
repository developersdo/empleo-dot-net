using System;
using System.Collections.Generic;
using Api.Contract;

namespace Api
{
    public class MobileApi : IMobileAPI
    {
        IList<JobDto> IMobileAPI.GetJobs()
        {
            throw new NotImplementedException();
        }
    }
}