using System;
using System.Collections.Generic;
using System.Reflection;
using System.Data.Entity;
using DataModel.HelperClasses;
using System.Linq;
using System.ComponentModel.Composition;


namespace DataModel
{
    /// <summary>
    /// Generic abstract class to Load / Add / Update / Delete single or multiple records
    /// </summary>
    /// <typeparam name="T"> T is any class who has implemented IAggregate Interface 
    /// and Inherited from IndexedListItem
    /// </typeparam>
    /// <typeparam name="M"> M is EntityObject class Database Table Name from where needs to be fetched 
    /// or need to load , Add , update or delete data
    /// </typeparam>
    [Export(typeof(IGenericComplexRepository<,>))]
    [PartCreationPolicy(System.ComponentModel.Composition.CreationPolicy.NonShared)]
    public class GenericComplexRepository<T, M> : IGenericComplexRepository<T, M>, IDisposable
        where T : IndexedListItem, IAggregateRoot, new()
        where M : BaseClassEntity
    {

        private DbSet<M> DbSet;
        private DbContext dataContext;

        /// <summary>
        /// Intiate DB context
        /// </summary>
        protected GenericComplexRepository()
        {
            this.dataContext = new mFrameworkDbContext();
            DbSet = dataContext.Set<M>();
        }

        /// <summary>
        ///  Add data from T into table M mentioned in Class Parameter
        /// </summary>
        /// <param name="entity">entity is any class of type T</param>
        /// <returns>return entity of Type T after successful insert with updated primary key from DB</returns>
        public void Add(T entity)
        {
            try
            {
                M objEntity = MapEntity(entity);
                objEntity = DbSet.Add(objEntity);
                dataContext.Entry(objEntity).State = EntityState.Added;
                dataContext.SaveChanges();
            }

            catch
            {
                throw;
            }

        }

        /// <summary>
        ///  Add number of records from List<T> into table M mentioned in Class Parameter
        /// </summary>
        /// <param name="entityList">entityList is a list of entities of any class of type T</param>
        public void Add(List<T> entityList)
        {
            try
            {
                foreach (var entity in entityList)
                {
                    M objEntity = MapEntity(entity);
                    objEntity = DbSet.Add(objEntity);
                    dataContext.SaveChanges();
                }

            }
            catch
            {

                throw;
            }

        }

        /// <summary>
        /// Update working entity received from UI into existing entity avilable in table M
        /// </summary>
        /// <param name="entity"></param>
        public void Update(T entity)
        {
            try
            {
                M updatedItem = MapEntity(entity);
                DbSet.Attach(updatedItem);
                dataContext.Entry(updatedItem).State = EntityState.Modified;
                dataContext.SaveChanges();
            }
            catch
            {
                throw;
            }

        }

        /// <summary>
        /// remove record of entity T from table M if exist
        /// </summary>
        /// <param name="entity"></param>
        public void Remove(T entity)
        {
            try
            {
                M objEntity = MapEntity(entity);
                if (dataContext.Entry(objEntity).State == EntityState.Detached)
                {
                    DbSet.Attach(objEntity);
                }
                DbSet.Remove(objEntity);
                dataContext.SaveChanges();
            }
            catch
            {
                throw;
            }

        }

        /// <summary>
        /// remove record of entity T from table M if exist
        /// </summary>
        /// <param name="entity"></param>
        public void RemoveById(int Id)
        {
            try
            {
                M ObjM = DbSet.Find(Id);
                if (ObjM != null)
                {
                    if (dataContext.Entry(ObjM).State == EntityState.Detached)
                    {
                        DbSet.Attach(ObjM);
                    }
                    DbSet.Remove(ObjM);
                    dataContext.SaveChanges();
                }
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Find all records avilable in table M
        /// </summary>
        /// <returns>returns list of T by mapping all records avilable in table M</returns>
        public List<T> FindAll()
        {
            try
            {
                IQueryable<M> objT = DbSet;
                objT.AsNoTracking().ToList();
                List<T> objList = new List<T>();
                objList = MapTable(objT);
                return objList;
            }
            catch
            {
                throw;
            }

        }

        /// <summary>
        /// find the record from Table M by filtering with parameter id
        /// </summary>
        /// <param name="id">input parameter where id is expcted to be a primary key in table M</param>
        /// <returns></returns>
        public T FindById(int id)
        {
            try
            {
                DbSet<M> ResultSet = DbSet;
                M obj = ResultSet.Find(id);
                return MapTable(obj);
            }
            catch
            {

                throw;
            }

        }

        /// <summary>
        /// Map the result set from table M into the list of entities to be returned 
        /// to the requested layer using reflection
        /// </summary>
        /// <param name="ResultSet">List of records fetched from table M</param>
        /// <returns>List<T></returns>
        public List<T> MapTable(IQueryable<M> ResultSet)
        {
            List<T> objList = new List<T>();

            try
            {
                foreach (var item in ResultSet)
                {
                    T objEntity = new T();
                    Type fromObjectType = item.GetType();
                    Type toObjectType = objEntity.GetType();

                    object fromObj = item;
                    object toObj = objEntity;



                    foreach (PropertyInfo fromProperty in fromObjectType.GetProperties())
                    {
                        if (fromProperty.CanRead)
                        {
                            string fromPropertyName = fromProperty.Name;


                            PropertyInfo toPropertyName = toObjectType.GetProperty(fromPropertyName);
                            if (toPropertyName != null)
                            {

                                if (fromProperty != null)
                                {
                                    object fromValue = fromProperty.GetValue(fromObj, null);
                                    if (fromValue != null)
                                        toPropertyName.SetValue(toObj, fromValue, null);
                                }
                            }

                        }
                    }
                    objList.Add((T)toObj);

                }

            }
            catch
            {
                throw;
            }
            return objList;
        }

        /// <summary>
        /// Map a record fetched from table M into the entity to be returned 
        /// to the requested layer using reflection
        /// </summary>
        /// <param name="item">a data record from table M</param>
        /// <returns>single entity data feteched from table M</returns>
        private T MapTable(M item)
        {

            T objEntity = new T();
            object toObj = objEntity;
            object fromObj = item;
            try
            {
                Type fromObjectType = item.GetType();
                Type toObjectType = objEntity.GetType();
                foreach (PropertyInfo fromProperty in fromObjectType.GetProperties())
                {
                    if (fromProperty.CanRead)
                    {
                        string fromPropertyName = fromProperty.Name;
                        PropertyInfo toPropertyName = toObjectType.GetProperty(fromPropertyName);
                        if (toPropertyName != null)
                        {
                            if (fromProperty != null)
                            {
                                object fromValue = fromProperty.GetValue(fromObj, null);
                                if (fromValue != null)
                                    toPropertyName.SetValue(toObj, fromValue, null);
                            }
                        }

                    }

                }

            }
            catch
            {
                throw;
            }
            return (T)toObj;
        }

        /// <summary>
        /// Map the entity data received from class T from requested layer into the entity object of M using reflection
        /// </summary>
        /// <param name="entity">entity with filled data from requested layer</param>
        /// <returns>entity object to be inserted / updated or deleted from table M</returns>
        private M MapEntity(T entity)
        {
            try
            {
                M objtable;
                objtable = (M)entity.GetTableName;

                Type fromObjectType = entity.GetType();
                Type toObjectType = objtable.GetType();

                object fromObj = entity;
                object toObj = objtable;

                foreach (PropertyInfo toProperty in toObjectType.GetProperties())
                {
                    if (toProperty.CanRead)
                    {
                        string toPropertyName = toProperty.Name;


                        PropertyInfo fromPropertyName = fromObjectType.GetProperty(toPropertyName);
                        if (fromPropertyName != null)
                        {

                            if (toProperty != null)
                            {
                                object fromValue = fromPropertyName.GetValue(fromObj, null);
                                if (fromValue != null)
                                    toProperty.SetValue(toObj, fromValue, null);
                            }
                        }

                    }
                }
                return objtable;
            }
            catch
            {

                throw;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {

        }
    }
}
