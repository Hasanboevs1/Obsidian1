using Microsoft.EntityFrameworkCore;
using Obsidian.Data.DbContexts;
using Obsidian.Data.IRepositories;
using Obsidian.Domain.Commons;

namespace Obsidian.Data.Repositories;

public class Repository<TEntity> : IRepository<TEntity> where TEntity : Auditable
{
    private readonly AppDbContext _db;
    private readonly DbSet<TEntity> _dbSet;

    public Repository(AppDbContext db)
    {
        _db = db;
        _dbSet = _db.Set<TEntity>();
    }

    public async Task<TEntity> InsertAsync(TEntity entity)
    {
        var entry = await _dbSet.AddAsync(entity);

        await _db.SaveChangesAsync();

        return entry.Entity;
    }


    public async Task<bool> DeleteAsync(long id)
    {
        var entity = await _dbSet.FirstOrDefaultAsync(e => e.Id == id);
        _dbSet.Remove(entity);

        return await _db.SaveChangesAsync() > 0;
    }


    public IQueryable<TEntity> SelectAllAsync()
        => _dbSet;

    public async Task<TEntity> SelectByIdAsync(long id)
        => await _dbSet.FirstOrDefaultAsync(e => e.Id == id);

    public async Task<TEntity> UpdateAsync(TEntity entity)
    {
        var entry = _db.Update(entity);
        await _db.SaveChangesAsync();

        return entry.Entity;
    }
}
