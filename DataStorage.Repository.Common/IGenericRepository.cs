using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DataStorage.Repository.Common
{
    public interface IGenericRepository<T> where T: class
    {
        /// <summary>
        /// Generic asynchronous  Get method to get record on the basis of id
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        Task<T> Get(int i);

        /// <summary>
        /// Get all records asynchronous
        /// </summary>
        /// <returns></returns>
        Task<IQueryable<T>> GetAll();

        /// <summary>
        /// Generic asynchronous add method to insert enities to collection 
        /// </summary>
        /// <param name="entity"></param>
        Task Add(T entity);

        /// <summary>
        /// Generic asynchronous delete method to delete record on the basis of id
        /// </summary>
        /// <param name="queryExpression"></param>
        /// <param name="id"></param>
        Task Delete(Expression<Func<T, int>> queryExpression, int id);

        /// <summary>
        ///  Generic asynchronous update method to delete record on the basis of id
        /// </summary>
        /// <param name="queryExpression"></param>
        /// <param name="id"></param>
        /// <param name="entity"></param>
        Task Update(Expression<Func<T, int>> queryExpression, int id, T entity);


    }
}
