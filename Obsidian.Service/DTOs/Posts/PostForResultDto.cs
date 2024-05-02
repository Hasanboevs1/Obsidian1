using Obsidian.Domain.Entities;

namespace Obsidian.Service.DTOs.Posts;

public class PostForResultDto
{
    public long Id { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public User Owner { get; set; }
    public ICollection<Comment> Comments { get; set; }
}

