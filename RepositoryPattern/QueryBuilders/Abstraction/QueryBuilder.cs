using Microsoft.EntityFrameworkCore;
using RepositoryPattern.Abstraction;
using System.Linq.Expressions;

namespace RepositoryPattern.QueryBuilders.Abstraction
{
    public class QueryBuilder<TCurrent, TModel> : IQueryBuilder<TCurrent, TModel>
    where TCurrent : QueryBuilder<TCurrent, TModel>
    where TModel : class, IEntity
    {
        private int _skip;
        private int _take = int.MaxValue;

        private Func<IQueryable<TModel>, IQueryable<TModel>> _orderByFilter = q => q;
        private readonly List<Expression<Func<TModel, bool>>> _queryFilters = new();
        private readonly List<Expression<Func<TModel, object>>> _includes = new();



        public IQueryable<TModel> BuildQuery(IQueryable<TModel> rootSet)
        {
            var query = _queryFilters.Aggregate(rootSet, (current, filter) => current.Where(filter));
            query = _includes.Aggregate(query, (current, include) => current.Include(include));
            query = _orderByFilter(query);
            return query.Skip(_skip).Take(_take);
        }

        public TCurrent Skip(int count)
        {
            _skip = count;
            return (TCurrent)this;
        }

        public TCurrent Take(int count)
        {

            _take = count;
            return (TCurrent)this;
        }

        protected TCurrent AddCondition(Expression<Func<TModel, bool>> condition)
        {
            _queryFilters.Add(condition);
            return (TCurrent)this;
        }

        protected TCurrent AddInclude(Expression<Func<TModel, object>> include)
        {
            _includes.Add(include);
            return (TCurrent)this;
        }

        protected TCurrent OrderBy<TKey>(Expression<Func<TModel, TKey>> keySelector, bool descending = false)
        {
            _orderByFilter = descending
                ? q => q.OrderByDescending(keySelector)
                : q => q.OrderBy(keySelector);

            return (TCurrent)this;
        }
    }
}
