using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EmpleoDotNet.Models.Repositories;

namespace EmpleoDotNet.Models.UnitOfWork
{
    public class UnitOfWork : IDisposable
    {
        #region context
        private Database context = new Database();
        #endregion

        #region Repositories
        private JobOpportunityRepository _jobOpportunityRepository;
        private LocationRepository _locationRepository;
        #endregion

        #region Repository Method
        public JobOpportunityRepository JobOpportunityRepository
        {
            get
            {
                return _jobOpportunityRepository ?? (_jobOpportunityRepository = new JobOpportunityRepository());
            }
        }

        public LocationRepository LocationRepository
        {
            get
            {
                return _locationRepository ?? (_locationRepository = new LocationRepository());
            }
        }
        #endregion

        #region Dispose
        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion

    }
}