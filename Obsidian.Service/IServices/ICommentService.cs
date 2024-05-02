using Obsidian.Service.DTOs.Comments;
using Obsidian.Service.DTOs.Users;

namespace Obsidian.Service.IServices;

public interface ICommentService
{
    public Task<CommentForResultDto> RetrieveByIdAsync(long id);
    public Task<bool> RemoveAsync(long id);
    public Task<IEnumerable<CommentForResultDto>> RetrieveAllAsync();
    public Task<CommentForResultDto> CreateAsync(CommentForCreationDto dto);
    public Task<CommentForResultDto> UpdateAsync(CommentForUpdateDto dto);
}
