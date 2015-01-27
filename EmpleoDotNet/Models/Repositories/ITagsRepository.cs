using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpleoDotNet.Models.Repositories
{
    public interface ITagsRepository
    {
        List<Tags> GetAllTags();
        List<JobOpportunity> GetJobOportunitiesByTag(string tag);
        Tags GetTagbByID(int? id);
        void AddOrUpdateTag(string[] tagsStrings);

    }
}
