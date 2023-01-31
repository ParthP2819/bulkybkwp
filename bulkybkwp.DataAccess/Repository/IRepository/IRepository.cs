﻿using System.Linq.Expressions;

namespace bulkybkw.DataAccess.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        //T - Category
        T GetFristOrDefault(Expression<Func<T,bool>>filter);
        IEnumerable<T> GetAll();    
        void Add(T entity);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entity);
    }
}
