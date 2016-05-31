using CodeAcademy.Airports.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeAcademy.Airports.RepositoryEF.Repositories
{
    public class GenericRepository<T> where T : class
    {
        Database db = new Database();

        public IQueryable<T> GetAll()
        {
            return db.Set<T>();
        }
        /// <summary>
        /// Returns null if there is no entity with that id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public T GetById(int id)
        {
            return db.Set<T>().Find(id);
        }

        /// <summary>
        /// Returns true if action was successfull.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool Create(T entity)
        {
            try
            {
                db.Set<T>().Add(entity);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// Returns true if action was successfull.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool Update(T entity)
        {
            try
            {
                db.Entry(entity).State = EntityState.Modified;
                db.SaveChanges();

                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        /// <summary>
        /// Returns true if action was successfull.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool Delete(T entity)
        {
            try
            {
                db.Set<T>().Remove(entity);
                db.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
