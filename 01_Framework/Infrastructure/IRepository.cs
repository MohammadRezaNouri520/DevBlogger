using _01_Framework.Domain;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace _01_Framework.Infrastructure
{
    public interface IRepository<TKey, T> where T:DomainBase<TKey>
    {
        List<T> GetAll();
        T Get(TKey id);
        void Create(T entity);
        bool Exists(Expression<Func<T, bool>> expression);
    }
}
