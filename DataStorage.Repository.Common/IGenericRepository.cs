using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataStorage.Repository.Common
{
    public interface IGenericRepository<T>
    {
        /// <summary>
        /// Generic asynchronous Get method to get record on the basis of id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="collectionName"></param>
        /// <returns>The document with given id.</returns>
        Task<T> GetAsync(Guid id, string collectionName);

        /// <summary>
        /// Get all records asynchronous
        /// </summary>
        ///  <param name="collectionName"></param>
        /// <returns>The documents in collection.</returns>
        Task<ICollection<T>> GetAllAsync(string collectionName);

        /// <summary>
        /// Generic asynchronous add method to insert enities to collection 
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="collectionName"></param>
        /// <returns>Created document.</returns>
        Task<T> AddAsync(T entity, string collectionName);

        /// <summary>
        /// Generic asynchronous delete method to delete record on the basis of id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="collectionName"></param>
        /// <returns>Is acknowledged bool.</returns>
        Task<bool> DeleteAsync(Guid id, string collectionName);

        /// <summary>
        ///  Generic asynchronous update method to delete record on the basis of id
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="collectionName"></param>
        /// <returns>Is acknowledged bool.</returns>
        Task<bool> UpdateAsync(T entity, string collectionName);

        /// <summary>
        /// Generic asynchronous GetAsync method to get record on the basis of query expression
        /// </summary>
        /// <param name="filterParams"></param>
        /// <param name="collectionName"></param>
        /// <returns>Documents that matches query expression.</returns>
        Task<ICollection<T>> GetAsync(ICollection<KeyValuePair<string, object>> filterParams, string collectionName);
    }
}
