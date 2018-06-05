using DataStorage.Model.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataStorage.Service.Common
{
    public interface IResourceService
    {
        Task<IResource> AddAsync(IResource resource, string appKey, string schemaName);
        Task<IResource> GetByIdAsync(Guid id, string appKey, string schemaName);
        Task<ICollection<IResource>> GetBySearchCriteriaAsync(string appKey, string schemaName, string searchQuery=null, int page = 1, int rpp= 10, string sort="asc");
        Task<bool> DeleteAsync(Guid id, string appKey, string schemaName);
        Task<bool> UpdateAsync(IResource resource, string appKey, string schemaName);
        Task<ICollection<IResource>> GetAllAsync(string appKey, string schemaName);
    }
}
