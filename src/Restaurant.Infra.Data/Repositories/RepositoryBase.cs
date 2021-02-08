using Microsoft.EntityFrameworkCore;
using Restaurant.Domain.Entities;
using Restaurant.Domain.Interfaces.Repositories;
using Restaurant.Infra.Data.Contexts;
using System.Collections.Generic;
using System.Linq;

namespace Restaurant.Infra.Data.Repositories
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity>
        where TEntity : EntityBase
    {
        protected readonly Context context;

        public RepositoryBase(Context context)
            : base()
        {
            this.context = context;
        }

        public int Insert(TEntity entity)
        {
            context.InitTransaction();

            var id = context.Set<TEntity>().Add(entity).Entity.Id;

            context.SendChanges();

            return id;
        }

        public void Update(TEntity entity)
        {
            context.InitTransaction();

            context.Set<TEntity>().Attach(entity);
            context.Entry(entity).State = EntityState.Modified;

            context.SendChanges();
        }

        public void Delete(int id)
        {
            var entity = FindById(id);
            if (entity != null)
            {
                Delete(entity);
            }
        }

        public void Delete(TEntity entity)
        {
            context.InitTransaction();
            context.Set<TEntity>().Remove(entity);
            context.SendChanges();
        }

        public TEntity FindById(int id)
        {
            return context.Set<TEntity>().Find(id);
        }

        public IEnumerable<TEntity> FindAll()
        {
            return context.Set<TEntity>().ToList();
        }

    }
}
