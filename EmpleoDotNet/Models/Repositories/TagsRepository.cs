using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmpleoDotNet.Models.Repositories
{
    public class TagsRepository: BaseRepository<Tags>,ITagsRepository
    {
        public List<JobOpportunity> GetJobOportunitiesByTag(string tag)
        {
            var jobOportunities = new JobOpportunityRepository();

            return jobOportunities
                    .GetAllJobOpportunities()
                    .Where(x=> x.Tag.Contains(tag))
                    .ToList();
        }


        public void AddOrUpdateTag(string[] tagsStrings)
        {
            foreach (var tag in tagsStrings)
            {
                var taginDB = GetAllTags().Find(x => x.TagName == tag.ToUpper());

                if (taginDB == null)
                {
                    Add(new Tags
                    {
                        TagName = tag.ToUpper(),
                        TagCount = 1,
                        Created = DateTime.Now
                    });
                }
                else
                {
                    taginDB.TagCount++;
                }
            }
        }

        public List<Tags> GetAllTags()
        {
            return GetAll().ToList();
        }


        public Tags GetTagbByID(int? id)
        {
            return GetById(id);
        }
    }
}