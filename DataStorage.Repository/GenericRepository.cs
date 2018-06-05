using DataStorage.Model.Common;
using DataStorage.Repository.Common;
using DataStorage.Repository.DatabaseSettings;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataStorage.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T: IDocument
    {
        #region Fields
        private readonly IMongoDatabase _database;
        #endregion Fields
        #region Constructors
        public GenericRepository(IMongoClient client)
        {
            _database = client.GetDatabase(MongoDatabaseConfiguration.ConnectionString);
        }
        #endregion Constructors

        #region Methods


        public async Task<T> AddAsync(T entity, string collectionName)
        {
            try
            {
                await _database.GetCollection<T>(collectionName).InsertOneAsync(entity);
                return entity;
            }
            catch (Exception e)
            {
                return default(T);
            }
        }

        public async Task<T> GetAsync(Guid id, string collectionName)
        {
            try
            {
                return await _database.GetCollection<T>(collectionName).Find(x => x.Id.Equals(id)).FirstOrDefaultAsync();
            }
            catch(Exception e)
            {
                return default(T);
            }
        }

        public async Task<ICollection<T>> GetAllAsync(string collectionName)
        {
            try
            {
                return await _database.GetCollection<T>(collectionName).Find(Builders<T>.Filter.Empty).ToListAsync();
            }
            catch(Exception e)
            {
                return default(ICollection<T>);
            }
        }

        public async Task<bool> DeleteAsync(Guid id, string collectionName)
        {
            try
            {
                var deleteTask = await _database.GetCollection<T>(collectionName).DeleteOneAsync(x => x.Id.Equals(id));
                return deleteTask.IsAcknowledged;
            }
            catch(Exception e)
            {
                return false;
            }
        }

        public async Task<bool> UpdateAsync(T entity, string collectionName)
        {
            try{
                var updateTask = await _database.GetCollection<T>(collectionName).ReplaceOneAsync(x => x.Id.Equals(entity.Id), entity);
                return updateTask.IsAcknowledged;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public async Task<ICollection<T>> GetAsync(ICollection<KeyValuePair<string, object>> filterParams , string collectionName)
        {
            try
            {
                return await _database.GetCollection<T>(collectionName).Find(new BsonDocument(filterParams)).ToListAsync();
            }
            catch(Exception e)
            {
                return default(ICollection<T>);
            }
        }
        #endregion Methods
    }
}
