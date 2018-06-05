using DataStorage.Repository.Common;
using DataStorage.Service.Common;
using System;
using System.Collections.Generic;
using System.Text;
using DataStorage.Model.Common;
using System.Threading.Tasks;

namespace DataStorage.Service
{
    public class SchemaService: ISchemaService
    {
        #region Properties

        protected ISchemaRepository SchemaRepository { get; private set; }

        #endregion Properties

        #region Constructors
        public SchemaService(ISchemaRepository schemaRepository)
        {
            SchemaRepository = schemaRepository;
        }
        #endregion Constructors

        #region Methods

        public Task<ISchema> AddAsync(ISchema schema, string appKey)
        {
            throw new NotImplementedException();
        }

        public Task<ISchema> GetByIdAsync(Guid id, string appKey)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<ISchema>> GetBySearchCriteriaAsync(string appKey, string searchQuery = null, int page = 1, int rpp = 10, string sort = "asc")
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(Guid id, string appKey)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(ISchema schema, string appKey)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<ISchema>> GetAllAsync(string appKey)
        {
            throw new NotImplementedException();
        }

        
        #endregion Methods
    }
}
