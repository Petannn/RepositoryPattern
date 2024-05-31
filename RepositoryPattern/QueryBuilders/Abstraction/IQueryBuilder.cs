namespace RepositoryPattern.QueryBuilders.Abstraction
{
    public interface IQueryBuilder<out TCurrent, TModel>
    {
        IQueryable<TModel> BuildQuery(IQueryable<TModel> rootSet);

        TCurrent Skip(int count);
        TCurrent Take(int count);

    }
}
