using Obsidian.Data.IRepositories;
using Obsidian.Service.DTOs.Users;
using Obsidian.Service.IServices;

namespace Obsidian.Service.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _repo;
    public UserService(IUserRepository repo)
    {
        _repo = repo;
    }
    public Task<UserForResultDto> CreateAsync(UserForCreationDto dto)
    {
        throw new NotImplementedException();
    }

    public Task<bool> RemoveAsync(long id)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<UserForResultDto> RetrieveAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<UserForResultDto> RetrieveByIdAsync(long id)
    {
        throw new NotImplementedException();
    }

    public Task<UserForResultDto> UpdateAsync(UserForUpdateDto dto)
    {
        throw new NotImplementedException();
    }
}
