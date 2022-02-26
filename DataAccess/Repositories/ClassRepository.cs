namespace DataAccess.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using DataAccess.Repositories.Abstraction;
    using Domain;
    using NHibernate;

    public class ClassRepository : IRepository<Class>
    {
        public Class Get(ISession session, int id) =>
            session?.Get<Class>(id);

        public Class Find(ISession session, Expression<Func<Class, bool>> predicate)
        {
            return this.GetAll(session).FirstOrDefault(predicate);
        }

        public IQueryable<Class> GetAll(ISession session) =>
            session?.Query<Class>();

        public IQueryable<Class> Filter(ISession session, Expression<Func<Class, bool>> predicate)
        {
            return this.GetAll(session).Where(predicate);
        }

        public bool Create<TEntity>(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete<TEntity>(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public bool Update<TEntity>(TEntity oldEntity, TEntity newEntity)
        {
            throw new NotImplementedException();
        }
    }
}
