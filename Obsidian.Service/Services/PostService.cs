using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Obsidian.Data.IRepositories;
using Obsidian.Domain.Entities;
using Obsidian.Service.DTOs.Posts;
using Obsidian.Service.DTOs.Users;
using Obsidian.Service.Exceptions;
using Obsidian.Service.IServices;

namespace Obsidian.Service.Services;

public class PostService : IPostService
{
    private readonly IPostRepository _repo;
    private readonly IMapper _mapper;
    public PostService(IPostRepository repo, IMapper mapper)
    {
        _repo = repo;
        _mapper = mapper;
    }
    public async Task<PostForResultDto> CreateAsync(PostForCreationDto dto)
    {
        var post = await _repo.SelectAllAsync()
            .FirstOrDefaultAsync(x => x.Title.ToLower() == dto.Title.ToLower());
        if (post is not null)
            throw new CustomException(409, "Already exists");

        var mappedPost = _mapper.Map<Post>(dto);
        mappedPost.CreatedAt = DateTime.UtcNow;

        var result = _repo.InsertAsync(mappedPost);
        return _mapper.Map<PostForResultDto>(result);
    }

    public async Task<bool> DeleteAsync(long id)
    {
        var post = await _repo.SelectByIdAsync(id);
        if (post is null)
            throw new CustomException(404, "Not Found");
        await _repo.DeleteAsync(id);
        return true;
    }

    public async Task<IEnumerable<PostForResultDto>> RetrieveAllAsync()
    {
        var posts = await _repo.SelectAllAsync().ToListAsync();

        return _mapper.Map<IEnumerable<PostForResultDto>>(posts);
    }

    public async Task<PostForResultDto> RetrieveByIdAsync(long id)
    {
        var post = await _repo.SelectByIdAsync(id);
        if (post is null)
            throw new CustomException(404, "Not Found");

        return _mapper.Map<PostForResultDto>(post);
    }

    public async Task<PostForResultDto> UpdateAsync(PostForUpdateDto dto)
    {
        var post = await _repo.SelectByIdAsync(dto.Id);
        if (post is null)
            throw new CustomException(404, "Not found");
        var mappedPost = _mapper.Map<Post>(dto);
        mappedPost.UpdatedAt = DateTime.UtcNow;

        var result = await _repo.UpdateAsync(mappedPost);
        return _mapper.Map<PostForResultDto>(result);
    }
}
