using DataStorage.Repository.Common;
using DataStorage.Service.Common;
using System;
using System.Collections.Generic;
using System.Text;
using DataStorage.Model.Common;
using System.Threading.Tasks;

namespace DataStorage.Service
{
    public class ResourceService: IResourceService
    {
        #region Properties

        protected IResourceRepository ResourceRepository { get; private set; }

        #endregion Properties

        #region Constructors

        public ResourceService(IResourceRepository resourceRepository)
        {
            ResourceRepository = resourceRepository;
        }
        #endregion Constructors

        #region Methodss
        public Task<IResource> AddAsync(IResource resource, string appKey, string schemaName)
        {
            throw new NotImplementedException();
        }

        public Task<IResource> GetByIdAsync(Guid id, string appKey, string schemaName)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<IResource>> GetBySearchCriteriaAsync(string appKey, string schemaName, string searchQuery = null, int page = 1, int rpp = 10, string sort = "asc")
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(Guid id, string appKey, string schemaName)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(IResource resource, string appKey, string schemaName)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<IResource>> GetAllAsync(string appKey, string schemaName)
        {
            throw new NotImplementedException();
        }

        #endregion Methods
    }
}
