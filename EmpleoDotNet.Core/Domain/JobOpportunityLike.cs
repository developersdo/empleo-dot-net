using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpleoDotNet.Core.Domain
{
    public class JobOpportunityLike : EntityBase
    {
        #region Property

        public bool Like { get; set; }

        public int JobOpportunityId { get; set; }

        #endregion

        #region Navegation Properties

        public JobOpportunity JobOpportunity { get; set; }

        #endregion
    }
}
