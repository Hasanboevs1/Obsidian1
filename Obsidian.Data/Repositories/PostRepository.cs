using Obsidian.Data.DbContexts;
using Obsidian.Data.IRepositories;
using Obsidian.Domain.Entities;

namespace Obsidian.Data.Repositories;

public class PostRepository : Repository<Post>, IPostRepository
{
    public PostRepository(AppDbContext db) : base(db)
    {
    }
}

