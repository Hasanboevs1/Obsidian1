using Obsidian.Data.IRepositories;
using Obsidian.Service.DTOs.Posts;
using Obsidian.Service.IServices;

namespace Obsidian.Service.Services;

public class PostService : IPostService
{
    private readonly IPostRepository _repo;

    public PostService(IPostRepository repo)
    {
        _repo = repo;
    }

    public Task<PostForResultDto> CreateAsync(PostForCreationDto dto)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteById(long id)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<PostForResultDto> RetrieveAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<PostForResultDto> RetrieveById(long id)
    {
        throw new NotImplementedException();
    }

    public Task<PostForResultDto> UpdateAsync(PostForUpdateDto dto)
    {
        throw new NotImplementedException();
    }
}
