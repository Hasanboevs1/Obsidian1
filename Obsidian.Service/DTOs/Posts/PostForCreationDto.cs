using Obsidian.Domain.Entities;

namespace Obsidian.Service.DTOs.Posts;

public class PostForCreationDto
{
    public string Title { get; set; }
    public string Content { get; set; }
}
