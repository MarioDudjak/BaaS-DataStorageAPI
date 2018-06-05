using DataStorage.Repository.Common;
using System;
using System.Collections.Generic;
using System.Text;
using DataStorage.Model.Common;
using System.Threading.Tasks;

namespace DataStorage.Repository
{
    public class ResourceRepository : IResourceRepository
    {
        #region Fields
        protected IGenericRepository<IResource> GenericRepository { get; private set; }
        #endregion Fields

        #region Constructors
        public ResourceRepository(IGenericRepository<IResource> genericRepository)
        {
            GenericRepository = genericRepository;
        }
        #endregion Constructors


        #region Methods
        public async Task<IResource> AddAsync(IResource resource, string collectionName)
        {
            return await GenericRepository.AddAsync(resource, collectionName);
        }

        public async Task<bool> DeleteAsync(Guid id, string collectionName)
        {
            return await GenericRepository.DeleteAsync(id, collectionName);
        }

        public async Task<IResource> GetByIdAsync(Guid id, string collectionName)
        {
            return await GenericRepository.GetAsync(id, collectionName);
        }

        public async Task<ICollection<IResource>> GetBySearchCriteriaAsync(ICollection<KeyValuePair<string, object>> filterParams, string collectionName)
        {
            return await GenericRepository.GetAsync(filterParams, collectionName);
        }

        public async Task<bool> UpdateAsync(IResource resource, string collectionName)
        {
            return await GenericRepository.UpdateAsync(resource, collectionName);
        }

        public async Task<ICollection<IResource>> GetAllAsync(string collectionName)
        {
            return await GenericRepository.GetAllAsync(collectionName);
        }
        #endregion Methods
    }
}
