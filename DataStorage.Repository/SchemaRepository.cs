using DataStorage.Repository.Common;
using System;
using DataStorage.Model.Common;
using System.Threading.Tasks;
using MongoDB.Driver;
using DataStorage.Repository.DatabaseSettings;
using MongoDB.Bson;
using System.Collections.Generic;

namespace DataStorage.Repository
{
    public class SchemaRepository : ISchemaRepository
    {

        #region Fields
        private readonly IMongoDatabase _database;
        protected IGenericRepository<ISchema> GenericRepository { get; private set; }
        #endregion Fields
        #region Constructors
        public SchemaRepository(IMongoClient client, IGenericRepository<ISchema> genericRepository)
        {
            _database = client.GetDatabase(MongoDatabaseConfiguration.ConnectionString);
            GenericRepository = genericRepository;
        }
        #endregion Constructors


        #region Methods
        public async Task<ISchema> AddAsync(ISchema schema, string appSchemasCollectionName)
        {
            CreateCollectionOptions options = schema.Options.ToObject<CreateCollectionOptions>();
            await _database.CreateCollectionAsync(schema.Name, options);
            return await GenericRepository.AddAsync(schema, appSchemasCollectionName);
        }

        public async Task<ISchema> GetByNameAsync(string schemaName, string appSchemasCollectionName)
        {
            return await _database.GetCollection<ISchema>(appSchemasCollectionName).Find(new BsonDocument { { "name", schemaName } }).FirstAsync();
        }

        public async Task<ICollection<ISchema>> GetBySearchCriteriaAsync(ICollection<KeyValuePair<string, object>> filterParams, string appSchemasCollectionName)
        {
            return await GenericRepository.GetAsync(filterParams, appSchemasCollectionName);
        }

        public async Task<bool> DeleteAsync(string schemaName, string appSchemasCollectionName)
        {
            await _database.DropCollectionAsync(schemaName);
            var deleteTask = await _database.GetCollection<ISchema>(appSchemasCollectionName).DeleteOneAsync(x => x.Name.Equals(schemaName));
            return deleteTask.IsAcknowledged;
        }

        public async Task<bool> UpdateAsync(ISchema schema, string appSchemasCollectionName)
        {
            await _database.DropCollectionAsync(schema.Name);
            await this.AddAsync(schema, appSchemasCollectionName);
            return await GenericRepository.UpdateAsync(schema, appSchemasCollectionName);
        }

        public async Task<ICollection<ISchema>> GetAllAsync(string appSchemasCollectionName)
        {
            return await GenericRepository.GetAllAsync(appSchemasCollectionName);
        }

        #endregion Methods
    }
}
