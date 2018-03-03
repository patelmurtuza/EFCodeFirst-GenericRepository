using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using DataModel.HelperClasses;
using System.Data.Entity.Validation;
using System.ComponentModel.Composition;

namespace DataModel
{
    [Export(typeof(IGenericRepository<>))]
    [PartCreationPolicy(System.ComponentModel.Composition.CreationPolicy.NonShared)]
    public class GenericRepository<T> : IDisposable, IGenericRepository<T> where T : IndexedListItem, new()
    {
        internal mFrameworkDbContext objmFrameworkDbContext;
        internal DbSet<T> dbSet;

        public GenericRepository()
        {
            this.objmFrameworkDbContext = new mFrameworkDbContext();
            this.dbSet = objmFrameworkDbContext.Set<T>();
        }

        public IEnumerable<T> GetAll()
        {
            IQueryable<T> objT = dbSet;
            return objT.AsNoTracking().ToList();
        }

        public T GetByID(object id)
        {
            T obj = dbSet.Find(id);
            objmFrameworkDbContext.Entry(obj).State = EntityState.Detached;
            return obj;
        }

        public IEnumerable<T> FilterByParam(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            try
            {
                return dbSet.AsNoTracking().Where(predicate).ToList();
            }
            catch
            {

                throw;
            }

        }

        public void Insert(T obj)
        {
            dbSet.Add(obj);
            Save();
        }

        public void Update(T obj)
        {
            try
            {
                dbSet.Attach(obj);
                objmFrameworkDbContext.Entry(obj).State = EntityState.Modified;
                Save();
            }
            catch
            {
                throw;
            }

        }

        public void Delete(int id)
        {
            T ObjT = dbSet.Find(id);
            if (ObjT != null)
            {
                Delete(ObjT);
            }
            Save();

        }

        public virtual void Delete(T obj)
        {
            if (objmFrameworkDbContext.Entry(obj).State == EntityState.Detached)
            {
                dbSet.Attach(obj);
            }
            dbSet.Remove(obj);
            Save();
        }

        private void Save()
        {
            try
            {
                objmFrameworkDbContext.SaveChanges();
            }

            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;
            }
            catch
            {
                throw;
            }

        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.Dispose();
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
