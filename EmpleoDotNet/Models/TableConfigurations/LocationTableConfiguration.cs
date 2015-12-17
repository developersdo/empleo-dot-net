namespace EmpleoDotNet.Models.TableConfigurations
{
    public class LocationTableConfiguration : TableConfiguration<Location>
    {
        public LocationTableConfiguration()
        {
            Ignore(x => x.Created);
            Property(x => x.Name).IsRequired();
        }
    }
}