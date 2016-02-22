namespace EmpleoDotNet.Core.Domain
{
    public class JobOpportunityLocation
    {
        public int Id { get; set; }
        public string PlaceId { get; set; }
        public string Name { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
    }
}