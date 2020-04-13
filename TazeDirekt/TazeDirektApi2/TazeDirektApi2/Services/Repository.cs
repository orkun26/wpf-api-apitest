using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using TazeDirektApi2.Data;

namespace TazeDirektApi2.Services
{
    public class Repository<T> : IRepository<T> where T : class
    {
        TazeDirektEntities _entites = new TazeDirektEntities();
        private readonly DbSet<T> _dbSet;
        public Repository()
        {

            if (_entites == null)
            {
                throw new ArgumentNullException("Entites Model  can not be null.");
            }

            _dbSet = _entites.Set<T>();
        }
        public void Insert(T entity)
        {
            _dbSet.Add(entity);
            _entites.SaveChanges();
        }

        public void Delete(int id)
        {
           var entity = GetById(id);
            if (entity == null) return;
            else
            {
                _dbSet.Attach(entity);
                _entites.Entry(entity).State = EntityState.Deleted;

                _entites.SaveChanges();
            }
        }

        public IEnumerable<T> GetAll()
        {
            return _dbSet;
        }

        public void Update(T entity)
        {


            _dbSet.Attach(entity);
            _entites.Entry(entity).State = EntityState.Modified;
            _entites.SaveChanges();
        }

        public T GetById(int id)
        {
            return _dbSet.Find(id);
        }
    }
}