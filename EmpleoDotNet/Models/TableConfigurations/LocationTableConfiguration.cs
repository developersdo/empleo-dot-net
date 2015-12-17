namespace EmpleoDotNet.Models.TableConfigurations
{
    public class LocationTableConfiguration : BaseTableConfiguration<Location>
    {
        public LocationTableConfiguration()
        {
            Property(x => x.Name).IsRequired();
        }
    }
}