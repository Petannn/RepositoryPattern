namespace RepositoryPattern.Repositories.Abstraction
{
    public interface IRepositoryBase<TDto>
    {
        Task<Guid> CreateAsync(TDto newItem, CancellationToken cancellationToken);

        Task UpdateAsync(TDto updated, CancellationToken cancellationToken);

        Task UpdateAsync(TDto[] updated, CancellationToken cancellationToken);

        Task<TDto> GetAsync(Guid id, CancellationToken cancellationToken);

        Task<TDto[]> GetAsync(CancellationToken cancellationToken, params Guid[] stateIds);

        Task DeleteAsync(Guid id, CancellationToken cancellationToken);

        Task DeleteAsync(CancellationToken cancellationToken, Guid[] ids);
    }
}