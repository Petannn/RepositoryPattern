using RepositoryPattern.Dto;
using RepositoryPattern.Models;
using RepositoryPattern.QueryBuilders;
using RepositoryPattern.Repositories.Abstraction;
using RepositoryPattern.Repositories.Base;

namespace RepositoryPattern.Repositories
{
    public class DummyRepository : QueryableRepository<DummyQueryBuilder, DummyModel, DummyDto>, IDummyRepository
    {
        public DummyRepository(CustomDbContext dbContext) : base(dbContext)
        {
        }

        protected override DummyModel MapToModel(DummyDto dto)
        {
            return new DummyModel
            {
                Id = dto.Id,
                X = dto.X,
                Y = dto.Y,
                Z = dto.Z,
            };
        }

        protected override DummyDto MapToDto(DummyModel model)
        {
            return new DummyDto
            {
                Id = model.Id,
                X = model.X,
                Y = model.Y,
                Z = model.Z,
            };

        }
    }
}