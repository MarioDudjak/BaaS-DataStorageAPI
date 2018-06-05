using DataStorage.Model.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataStorage.Service.Common
{
    public interface ISchemaService
    {
        Task<ISchema> AddAsync(ISchema schema, string appKey);
        Task<ISchema> GetByIdAsync(Guid id, string appKey);
        Task<ICollection<ISchema>> GetBySearchCriteriaAsync(string appKey, string searchQuery = null, int page = 1, int rpp = 10, string sort = "asc");
        Task<bool> DeleteAsync(Guid id, string appKey);
        Task<bool> UpdateAsync(ISchema schema, string appKey);
        Task<ICollection<ISchema>> GetAllAsync(string appKey);
    }
}
