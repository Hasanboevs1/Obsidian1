
using Obsidian.Service.DTOs.Users;

namespace Obsidian.Service.IServices;

public interface IUserService
{
    public Task<UserForResultDto> RetrieveByIdAsync(long id);
    public Task<bool> RemoveAsync(long id);
    public IEnumerable<UserForResultDto> RetrieveAllAsync();
    public Task<UserForResultDto> CreateAsync(UserForCreationDto dto);
    public Task<UserForResultDto> UpdateAsync(UserForUpdateDto dto);
}
