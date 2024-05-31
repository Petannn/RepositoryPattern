using RepositoryPattern.Dto;
using RepositoryPattern.QueryBuilders;
using RepositoryPattern.Repositories.Abstraction;

namespace RepositoryPattern.Repositories.Abstraction
{
    public interface IDummyRepository : IQueryableRepository<DummyQueryBuilder, DummyDto>
    {
    }
}