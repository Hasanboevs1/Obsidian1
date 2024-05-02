using Obsidian.Domain.Entities;

namespace Obsidian.Service.DTOs.Comments;

public class CommentForResultDto
{
    public long Id { get; set; }
    public string Content { get; set; }
    public long OwnedId { get; set; }
    public User Owner { get; set; }
}
