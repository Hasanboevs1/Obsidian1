using Obsidian.Domain.Entities;

namespace Obsidian.Service.DTOs.Posts;

public class PostForUpdateDto
{
    public long Id { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
}
