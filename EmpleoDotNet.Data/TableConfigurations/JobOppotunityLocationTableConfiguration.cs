using System.Data.Entity.ModelConfiguration;
using EmpleoDotNet.Core.Domain;

namespace EmpleoDotNet.Data.TableConfigurations
{
    public class JobOppotunityLocationTableConfiguration : EntityTypeConfiguration<JobOpportunityLocation>
    {
        public JobOppotunityLocationTableConfiguration()
        {
            Property(x => x.Latitude).IsRequired();
            Property(x => x.Longitude).IsRequired();
            Property(x => x.Name).HasMaxLength(200).IsRequired();
            Property(x => x.PlaceId).HasMaxLength(100).IsRequired();
        }
    }
}