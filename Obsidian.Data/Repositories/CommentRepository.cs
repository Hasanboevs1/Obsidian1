using Obsidian.Data.DbContexts;
using Obsidian.Data.IRepositories;
using Obsidian.Domain.Entities;

namespace Obsidian.Data.Repositories;

public class CommentRepository : Repository<Comment>, ICommentRepository
{
    public CommentRepository(AppDbContext db) : base(db)
    {
    }
}
