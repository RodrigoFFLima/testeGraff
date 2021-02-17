using Graff.Database.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;

namespace Graff.Database.Repositories
{

    // Classe principal, que será herdada de todas as classes 'Repository'
    public class RepositoryBase<TEntity> : IDisposable where TEntity : class
    {
        protected readonly ModeloContainer _context = new ModeloContainer();

        public void Add(TEntity obj)
        {
            _context.Set<TEntity>().Add(obj);
            _context.SaveChanges();
        }

        public TEntity GetById(object id)
        {
            return _context.Set<TEntity>().Find(id);
        }

        public TEntity GetById(object[] ids)
        {
            return _context.Set<TEntity>().Find(ids);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _context.Set<TEntity>().AsEnumerable();
        }

        public void Update(TEntity obj)
        {
            _context.Entry(obj).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Remove(TEntity obj)
        {
            _context.Set<TEntity>().Remove(obj);
            _context.SaveChanges();
        }

        public void SetDeleted(TEntity obj)
        {
            _context.Entry(obj).State = EntityState.Deleted;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
