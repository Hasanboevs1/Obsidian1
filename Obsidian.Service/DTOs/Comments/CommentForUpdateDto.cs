using Obsidian.Domain.Entities;

namespace Obsidian.Service.DTOs.Comments;

public class CommentForUpdateDto
{
    public long Id { get; set; }
    public string Content { get; set; }
}

