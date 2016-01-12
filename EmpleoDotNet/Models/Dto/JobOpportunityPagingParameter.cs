namespace EmpleoDotNet.Models.Dto
{
    /// <summary>
    /// Parametro para realizar la consulta de Trabajos paginada por Ubicacion
    /// </summary>
    public class JobOpportunityPagingParameter
    {
        public string Keyword { get; set; }
        public int SelectedLocation { get; set; }
        public int PageSize { get; set; }
        public int Page { get; set; }
        public JobCategory JobCategory { get; set; }
    }
}