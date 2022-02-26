namespace DataAccess.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using DataAccess.Repositories.Abstraction;
    using Domain;
    using NHibernate;

    public class TeacherRepository : IRepository<Teacher>
    {
        public bool Create<TEntity>(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete<TEntity>(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Teacher> Filter(ISession session, System.Linq.Expressions.Expression<Func<Teacher, bool>> predicate)
        {
            return this.GetAll(session)
                .Where(predicate);
        }

        public Teacher Find(ISession session, System.Linq.Expressions.Expression<Func<Teacher, bool>> predicate)
        {
            return this.GetAll(session)
                .FirstOrDefault(predicate);
        }

        public Teacher Get(ISession session, int id) =>
                  session?.Get<Teacher>(id);

        public IQueryable<Teacher> GetAll(ISession session) =>
                  session?.Query<Teacher>();

        public bool Update<TEntity>(TEntity oldEntity, TEntity newEntity)
        {
            throw new NotImplementedException();
        }
    }
}
