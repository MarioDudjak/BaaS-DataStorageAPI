using DataStorage.Repository.Common;
using MongoDB.Driver;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DataStorage.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T:class
    {
        #region Fields


        #endregion Fields
        #region Constructors
        public GenericRepository()
        {
           
        }
        #endregion Constructors

        #region Methods
        public Task Add(T entity)
        {
            throw new NotImplementedException();
        }

        public Task Delete(Expression<Func<T, int>> queryExpression, int id)
        {
            throw new NotImplementedException();
        }

        public Task<T> Get(int i)
        {
            throw new NotImplementedException();
        }

        public Task<IQueryable<T>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task Update(Expression<Func<T, int>> queryExpression, int id, T entity)
        {
            throw new NotImplementedException();
        }
        #endregion Methods
    }
}
