using Microsoft.EntityFrameworkCore;
using RepositoryPattern.Abstraction;
using RepositoryPattern.QueryBuilders.Abstraction;
using RepositoryPattern.Repositories.Abstraction;

namespace RepositoryPattern.Repositories.Base
{
    public abstract class QueryableRepository<TQueryBuilder, TModel, TDto>
        : RepositoryBase<TModel, TDto>, IQueryableRepository<TQueryBuilder, TDto>
    where TQueryBuilder : IQueryBuilder<TQueryBuilder, TModel>, new()
    where TModel : class, IEntity, new()
    where TDto : class, IDto
    {
        private readonly CustomDbContext _dbContext;
        public QueryableRepository(CustomDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<TDto> First(TQueryBuilder builder, CancellationToken cancellationToken)
        {
            return MapToDto(await BuildBaseQuery(builder).FirstOrDefaultAsync(cancellationToken));
        }

        public Task<TDto> First(Func<TQueryBuilder, TQueryBuilder> buildFunction, CancellationToken cancellationToken)
        {
            return First(buildFunction(new TQueryBuilder()), cancellationToken);
        }

        public async Task<List<TDto>> All(TQueryBuilder builder, CancellationToken cancellationToken)
        {
            var dtoList = await BuildBaseQuery(builder).ToListAsync(cancellationToken);
            return dtoList.Select(MapToDto).ToList();
        }

        public Task<List<TDto>> All(Func<TQueryBuilder, TQueryBuilder> buildFunction, CancellationToken cancellationToken)
        {
            return All(buildFunction(new TQueryBuilder()), cancellationToken);
        }

        public Task<bool> Any(TQueryBuilder builder, CancellationToken cancellationToken)
        {
            return BuildBaseQuery(builder).AnyAsync(cancellationToken);
        }

        public Task<bool> Any(Func<TQueryBuilder, TQueryBuilder> buildFunction, CancellationToken cancellationToken)
        {
            return Any(buildFunction(new TQueryBuilder()), cancellationToken);
        }

        public Task<int> Count(Func<TQueryBuilder, TQueryBuilder> buildFunction, CancellationToken cancellationToken)
        {
            return Count(buildFunction(new TQueryBuilder()), cancellationToken);
        }

        public Task<int> Count(TQueryBuilder builder, CancellationToken cancellationToken)
        {
            return BuildBaseQuery(builder).CountAsync(cancellationToken);
        }

        private IQueryable<TModel> BuildBaseQuery(TQueryBuilder builder)
        {
            return builder.BuildQuery(_dbContext.Set<TModel>().AsNoTracking());
        }
    }
}
