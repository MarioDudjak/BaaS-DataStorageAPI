using DataStorage.Model.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataStorage.Repository.Common
{
    public interface ISchemaRepository
    {
        Task<ISchema> AddAsync(ISchema schema, string appSchemasCollectionName);
        Task<ISchema> GetByNameAsync(string schemaName, string appSchemasCollectionName);
        Task<ICollection<ISchema>> GetBySearchCriteriaAsync(ICollection<KeyValuePair<string, object>> filterParams, string appSchemasCollectionName);
        Task<bool> DeleteAsync(string schemaName, string appSchemasCollectionName);
        Task<bool> UpdateAsync(ISchema schema, string appSchemasCollectionName);
        Task<ICollection<ISchema>> GetAllAsync(string appSchemasCollectionName);

    }
}
