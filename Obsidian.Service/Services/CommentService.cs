using Obsidian.Data.IRepositories;
using Obsidian.Service.DTOs.Comments;
using Obsidian.Service.IServices;

namespace Obsidian.Service.Services;

public class CommentService : ICommentService
{
    private readonly ICommentRepository _repo;
    public Task<CommentForResultDto> CreateAsync(CommentForCreationDto dto)
    {
        throw new NotImplementedException();
    }

    public Task<bool> RemoveAsync(long id)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<CommentForResultDto> RetrieveAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<CommentForResultDto> RetrieveByIdAsync(long id)
    {
        throw new NotImplementedException();
    }

    public Task<CommentForResultDto> UpdateAsync(CommentForUpdateDto dto)
    {
        throw new NotImplementedException();
    }
}
