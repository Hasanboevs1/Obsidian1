using Obsidian.Data.DbContexts;
using Obsidian.Data.IRepositories;
using Obsidian.Domain.Entities;

namespace Obsidian.Data.Repositories;

public class UserRespository : Repository<User>, IUserRepository
{
    public UserRespository(AppDbContext db) : base(db)
    {
    }
}
