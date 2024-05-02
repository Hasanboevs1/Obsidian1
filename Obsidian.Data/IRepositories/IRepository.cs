using Obsidian.Domain.Commons;

namespace Obsidian.Data.IRepositories;

public interface IRepository<TEntity> where TEntity : Auditable
{
    public Task<TEntity> SelectByIdAsync(long id);
    public Task<bool> DeleteAsync(long id);
    public IQueryable<TEntity> SelectAllAsync();
    public Task<TEntity> InsertAsync(TEntity entity);
    public Task<TEntity> UpdateAsync(TEntity entity);
}
