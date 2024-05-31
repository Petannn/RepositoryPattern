using Microsoft.EntityFrameworkCore;
using RepositoryPattern.Abstraction;
using RepositoryPattern.Repositories.Abstraction;

namespace RepositoryPattern.Repositories.Base
{
    public abstract class RepositoryBase<TModel, TDto> : IRepositoryBase<TDto>
    where TModel : class, IEntity
    where TDto : class, IDto
    {
        private readonly CustomDbContext _dbContext;

        protected RepositoryBase(CustomDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Guid> CreateAsync(TDto newItem, CancellationToken cancellationToken)
        {
            var model = MapToModel(newItem);
            await _dbContext.Set<TModel>()
                .AddAsync(model, cancellationToken);

            await _dbContext.SaveChangesAsync(cancellationToken);
            return model.Id;
        }

        public async Task UpdateAsync(TDto updated, CancellationToken cancellationToken)
        {
            var model = MapToModel(updated);
            var modelDb = await _dbContext.Set<TModel>()
                .FirstAsync(m => m.Id == model.Id, cancellationToken);

            _dbContext.Entry(modelDb)
                .CurrentValues
                .SetValues(model);

            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task UpdateAsync(TDto[] updated, CancellationToken cancellationToken)
        {
            var models = updated.Select(MapToModel).ToArray();

            foreach (var model in models)
            {
                var modelDb = await _dbContext.Set<TModel>()
                    .FirstAsync(m => m.Id == model.Id, cancellationToken);

                _dbContext.Entry(modelDb)
                    .CurrentValues
                    .SetValues(model);
            }

            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task<TDto> GetAsync(Guid id, CancellationToken cancellationToken)
        {
            var model = await _dbContext.Set<TModel>()
                .AsNoTracking()
                .Where(u => u.Id == id)
                .FirstOrDefaultAsync(cancellationToken);
            return MapToDto(model);
        }

        public async Task<TDto[]> GetAsync(CancellationToken cancellationToken, params Guid[] ids)
        {
            var models = await _dbContext.Set<TModel>()
                .AsNoTracking()
                .Where(x => ids.Contains(x.Id))
                .ToArrayAsync(cancellationToken);

            return models.Select(MapToDto).ToArray();
        }

        public async Task DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            var item = await _dbContext
                .Set<TModel>()
                .FirstOrDefaultAsync(m => m.Id == id, cancellationToken);

            _dbContext
                .Set<TModel>()
                .Remove(item);

            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteAsync(CancellationToken cancellationToken, Guid[] ids)
        {
            var items = _dbContext
                .Set<TModel>()
                .Where(m => ids.Contains(m.Id))
                .ToArray();

            foreach (var item in items)
            {
                _dbContext.Set<TModel>()
                    .Remove(item);
            }

            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        protected abstract TModel MapToModel(TDto dto);

        protected abstract TDto MapToDto(TModel model);
    }
}
