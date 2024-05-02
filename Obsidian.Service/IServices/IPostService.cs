using Obsidian.Service.DTOs.Posts;

namespace Obsidian.Service.IServices;

public interface IPostService
{
    public Task<PostForResultDto> RetrieveByIdAsync(long id);
    public Task<bool> DeleteAsync(long id);
    public Task<IEnumerable<PostForResultDto>> RetrieveAllAsync();
    public Task<PostForResultDto> CreateAsync(PostForCreationDto dto);
    public Task<PostForResultDto> UpdateAsync(PostForUpdateDto dto);
}
