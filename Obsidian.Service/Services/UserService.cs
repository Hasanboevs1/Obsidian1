using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Obsidian.Data.IRepositories;
using Obsidian.Data.Repositories;
using Obsidian.Domain.Entities;
using Obsidian.Service.DTOs.Comments;
using Obsidian.Service.DTOs.Users;
using Obsidian.Service.Exceptions;
using Obsidian.Service.IServices;

namespace Obsidian.Service.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _repo;
    private readonly IMapper _mapper;
    public UserService(IUserRepository repo, IMapper mapper)
    {
        _repo = repo;
        _mapper = mapper;
    }
    public async Task<UserForResultDto> CreateAsync(UserForCreationDto dto)
    {
        var user = await _repo.SelectAllAsync()
            .FirstOrDefaultAsync(x => x.Email.ToLower() == dto.Email.ToLower());
        if (user is not null)
            throw new CustomException(409, "Already exists");

        var mappedUser = _mapper.Map<User>(dto);
        mappedUser.CreatedAt = DateTime.UtcNow;

        var result = _repo.InsertAsync(mappedUser);
        return _mapper.Map<UserForResultDto>(result);
    }

    public async Task<bool> RemoveAsync(long id)
    {
        var user = await _repo.SelectByIdAsync(id);
        if (user is null)
            throw new CustomException(404, "Not Found");
        await _repo.DeleteAsync(id);
        return true;
    }

    public async Task<IEnumerable<UserForResultDto>> RetrieveAllAsync()
    {
        var users = await _repo.SelectAllAsync().ToListAsync();

        return _mapper.Map<IEnumerable<UserForResultDto>>(users);
    }

    public async Task<UserForResultDto> RetrieveByIdAsync(long id)
    {
        var user = await _repo.SelectByIdAsync(id);
        if (user is null)
            throw new CustomException(404, "Not Found");

        return _mapper.Map<UserForResultDto>(user);
    }

    public async Task<UserForResultDto> UpdateAsync(UserForUpdateDto dto)
    {
        var user = await _repo.SelectByIdAsync(dto.Id);
        if (user is null)
            throw new CustomException(404, "Not found");
        var mappedUser = _mapper.Map<User>(dto);
        mappedUser.UpdatedAt = DateTime.UtcNow;

        var result = await _repo.UpdateAsync(mappedUser);
        return _mapper.Map<UserForResultDto>(result);
    }
}
