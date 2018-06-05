using DataStorage.Model.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataStorage.Repository.Common
{
    public interface IResourceRepository
    {
        Task<IResource> AddAsync(IResource resource, string collectionName);
        Task<IResource> GetByIdAsync(Guid id, string collectionName);
        Task<ICollection<IResource>> GetBySearchCriteriaAsync(ICollection<KeyValuePair<string, object>> filterParams, string collectionName);
        Task<bool> DeleteAsync(Guid id, string collectionName);
        Task<bool> UpdateAsync(IResource resource, string collectionName);
        Task<ICollection<IResource>> GetAllAsync(string collectionName);
    }
}
