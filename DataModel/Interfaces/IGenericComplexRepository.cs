using DataModel.HelperClasses;
using System.Collections.Generic;

namespace DataModel
{
    /// <summary>
    /// Generic interface which would be implmented in Generic Reposiotry class
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="M"></typeparam>
    public interface IGenericComplexRepository<T, M>
        where T : IndexedListItem, IAggregateRoot, new()
        where M : BaseClassEntity
    {
        void Add(List<T> entityList);
        void Add(T entity);
        void Update(T entity);
        void Remove(T entity);
        void RemoveById(int Id);
        List<T> FindAll();
        T FindById(int id);

    }
}
