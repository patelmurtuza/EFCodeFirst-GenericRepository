using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DataModel
{
    /// <summary>
    ///  Generic interface which would be implmented in Generic Reposiotry class
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IGenericRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T GetByID(object id);
        IEnumerable<T> FilterByParam(Expression<Func<T, bool>> predicate);
        void Insert(T obj);
        void Update(T obj);
        void Delete(int id);
    }
}
