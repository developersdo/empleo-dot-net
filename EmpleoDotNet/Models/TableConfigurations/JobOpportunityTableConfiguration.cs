using EmpleoDotNet.Core.Domain;

namespace EmpleoDotNet.Models.TableConfigurations
{
    /// <summary>
    /// Table configuration de la Tabla JobOpportunity
    /// </summary>
    public class JobOpportunityTableConfiguration : TableConfiguration<JobOpportunity>
    {
        public JobOpportunityTableConfiguration()
        {
            Property(x => x.Title).IsRequired();
            Property(x => x.Category).IsRequired();
            Property(x => x.Description).IsRequired();
            Property(x => x.CompanyName).HasMaxLength(150).IsRequired();
            Property(x => x.CompanyEmail).IsRequired();
        }
    }
}