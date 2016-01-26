namespace EmpleoDotNet.Models.Dto
{
    /// <summary>
    /// Parametro para realizar la consulta de empleos paginada por Ubicacion
    /// </summary>
    public class JobOpportunityPagingParameter
    {
        public string Keyword { get; set; }
        public int SelectedLocation { get; set; } = 0;
        public int PageSize { get; set; } = 15;
        public int Page { get; set; } = 1;
        public JobCategory JobCategory { get; set; } = JobCategory.All;
        public bool IsRemote { get; set; }
    }
}