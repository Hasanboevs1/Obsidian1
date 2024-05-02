using Obsidian.Service.DTOs.Posts;

namespace Obsidian.Service.IServices;

public interface IPostService
{
    public Task<PostForResultDto> RetrieveById(long id);
    public Task<bool> DeleteById(long id);
    public IEnumerable<PostForResultDto> RetrieveAllAsync();
    public Task<PostForResultDto> CreateAsync(PostForCreationDto dto);
    public Task<PostForResultDto> UpdateAsync(PostForUpdateDto dto);
}
