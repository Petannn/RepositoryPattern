namespace RepositoryPattern.Repositories.Abstraction
{
    public interface IQueryableRepository<TQueryBuilder, TDto> : IRepositoryBase<TDto>
    {
        Task<TDto> First(TQueryBuilder builder, CancellationToken cancellationToken);

        Task<TDto> First(Func<TQueryBuilder, TQueryBuilder> buildFunction, CancellationToken cancellationToken);

        Task<List<TDto>> All(TQueryBuilder builder, CancellationToken cancellationToken);

        Task<List<TDto>> All(Func<TQueryBuilder, TQueryBuilder> buildFunction, CancellationToken cancellationToken);

        Task<bool> Any(TQueryBuilder builder, CancellationToken cancellationToken);

        Task<bool> Any(Func<TQueryBuilder, TQueryBuilder> buildFunction, CancellationToken cancellationToken);

        Task<int> Count(TQueryBuilder builder, CancellationToken cancellationToken);

        Task<int> Count(Func<TQueryBuilder, TQueryBuilder> buildFunction, CancellationToken cancellationToken);
    }
}
