﻿using Microsoft.EntityFrameworkCore;

namespace EventsAPI.Repository
{
    public class UnitOfWork<TContext> : IRepositoryFactory, IUnitOfWork<EventsDbContext>, IUnitOfWork
        where TContext : DbContext, IDisposable
    {
        private Dictionary<Type, object> _repositories;
        public EventsDbContext Context { get; }
    
        public UnitOfWork(EventsDbContext context)
        {
            Context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public IRepository<TEntity> GetRepository<TEntity>() where TEntity : class
        {
            if (_repositories == null) _repositories = new Dictionary<Type, object>();

            var type = typeof(TEntity);
            if (!_repositories.ContainsKey(type)) _repositories[type] = new Repository<TEntity>(Context);
            return (IRepository<TEntity>)_repositories[type];
        }

        public int SaveChanges()
        {
            return Context.SaveChanges();
        }

        public void Dispose()
        {
            Context?.Dispose();
        }
    }
}
