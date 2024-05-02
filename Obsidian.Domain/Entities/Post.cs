using Obsidian.Domain.Commons;

namespace Obsidian.Domain.Entities;

public class Post : Auditable
{
    public string Title { get; set; }
    public string Content { get; set; }
    public User Owner { get; set; }
    public ICollection<Comment>? Comments { get; set; }
}
