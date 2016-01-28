using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using EmpleoDotNet.Models;

namespace EmpleoDotNet.Helpers
{
    public class JobCategoryHelper
    {
        public IList<JobCategoryLinkViewModel> GetPrimaryJobCategories()
        {
            var categories = new[]
            {
                new JobCategoryLinkViewModel
                {
                    Description = JobCategory.MobileDevelopment.ToEnumDescription(),
                    JobCategory = JobCategory.MobileDevelopment
                },
                new JobCategoryLinkViewModel
                {
                    Description = JobCategory.WebDevelopment.ToEnumDescription(),
                    JobCategory = JobCategory.WebDevelopment
                },
                new JobCategoryLinkViewModel
                {
                    Description = JobCategory.SoftwareDevelopment.ToEnumDescription(),
                    JobCategory = JobCategory.SoftwareDevelopment
                },
                new JobCategoryLinkViewModel
                {
                    Description = JobCategory.GraphicDesign.ToEnumDescription(),
                    JobCategory = JobCategory.GraphicDesign
                }
            };

            return categories;
        }
    }
}