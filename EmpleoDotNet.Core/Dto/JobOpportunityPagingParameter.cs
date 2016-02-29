using System;
using EmpleoDotNet.Core.Domain;

namespace EmpleoDotNet.Core.Dto
{
    /// <summary>
    /// Parametro para realizar la consulta de empleos paginada por Ubicacion
    /// </summary>
    public class JobOpportunityPagingParameter
    {
        public string Keyword { get; set; }
        public string SelectedLocationPlaceId { get; set; } = string.Empty;
        public string SelectedLocationName { get; set; } = string.Empty;
        public string SelectedLocationLatitude { get; set; }
        public string SelectedLocationLongitude { get; set; }
        public decimal LocationDistance { get; set; } = 15M;
        public int PageSize { get; set; } = 15;
        public int Page { get; set; } = 1;
        public JobCategory JobCategory { get; set; } = JobCategory.Invalid;
        public bool IsRemote { get; set; }

        public bool HasFilters
        {
            get
            {
                var result = false;

                if (JobCategory != JobCategory.All && JobCategory != JobCategory.Invalid)
                    result = true;

                if (!string.IsNullOrWhiteSpace(Keyword))
                    result = true;

                if (IsRemote)
                    result = true;

                return result;
            }
        }
    }
}