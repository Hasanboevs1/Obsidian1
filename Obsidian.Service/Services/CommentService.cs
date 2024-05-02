using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Obsidian.Data.IRepositories;
using Obsidian.Domain.Entities;
using Obsidian.Service.DTOs.Comments;
using Obsidian.Service.DTOs.Users;
using Obsidian.Service.Exceptions;
using Obsidian.Service.IServices;

namespace Obsidian.Service.Services;

public class CommentService : ICommentService
{
    private readonly ICommentRepository _repo;
    private readonly IMapper _mapper;
    public CommentService(ICommentRepository repo, IMapper mapper)
    {
        _repo = repo;
        _mapper = mapper;
    }
    public async Task<CommentForResultDto> CreateAsync(CommentForCreationDto dto)
    {
        var comment = await _repo.SelectAllAsync()
            .FirstOrDefaultAsync(x => x.Content.ToLower() == dto.Content.ToLower());
        if (comment is not null)
            throw new CustomException(409, "Already exists");

        var mappedComment = _mapper.Map<Comment>(dto);
        mappedComment.CreatedAt = DateTime.UtcNow;

        var result = _repo.InsertAsync(mappedComment);
        return _mapper.Map<CommentForResultDto>(result);
    }

    public async Task<bool> RemoveAsync(long id)
    {
        var comment = await _repo.SelectByIdAsync(id);
        if (comment is null)
            throw new CustomException(404, "Not Found");
        await _repo.DeleteAsync(id);
        return true;
    }

    public async Task<IEnumerable<CommentForResultDto>> RetrieveAllAsync()
    {
        var comments = await _repo.SelectAllAsync().ToListAsync();

        return _mapper.Map<IEnumerable<CommentForResultDto>>(comments);
    }

    public async Task<CommentForResultDto> RetrieveByIdAsync(long id)
    {
        var comment = await _repo.SelectByIdAsync(id);
        if (comment is null)
            throw new CustomException(404, "Not Found");

        return _mapper.Map<CommentForResultDto>(comment);
    }

    public async Task<CommentForResultDto> UpdateAsync(CommentForUpdateDto dto)
    {
        var comment = await _repo.SelectByIdAsync(dto.Id);
        if (comment is null)
            throw new CustomException(404, "Not found");
        var mappedComment = _mapper.Map<Comment>(dto);
        mappedComment.UpdatedAt = DateTime.UtcNow;

        var result = await _repo.UpdateAsync(mappedComment);
        return _mapper.Map<CommentForResultDto>(result);
    }
}
