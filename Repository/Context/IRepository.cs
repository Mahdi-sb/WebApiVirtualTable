using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Repository.Context
{
    public interface IRepository<TEntity> where TEntity :class
    {

        void Insert(TEntity entity);
        int GetIdOfTable(Expression<Func<TEntity, bool>> where, Expression<Func<TEntity, int>> select);
        bool FindValue(Expression<Func<TEntity, bool>> where);
        List<TEntity> GetAll();

        List<TEntity> TableColumn(Expression<Func<TEntity, bool>> where);

        List<string> AllType(Expression<Func<TEntity, bool>> where, Expression<Func<TEntity, string>> select);

    }
}
