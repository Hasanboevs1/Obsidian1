
using Microsoft.AspNetCore.Mvc;
using Obsidian.Service.DTOs.Comments;
using Obsidian.Service.DTOs.Posts;
using Obsidian.Service.IServices;

namespace Obsidian.Api.Controllers;

[Route("api/comment")]
[ApiController]
public class CommentsController : ControllerBase
{
    private readonly ICommentService _service;

    public CommentsController(ICommentService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
        => Ok(await _service.RetrieveAllAsync());


    [HttpGet("id")]
    public async Task<IActionResult> GetById(long id)
        => Ok(await _service.RetrieveByIdAsync(id));

    [HttpPost]
    public async Task<IActionResult> Create(CommentForCreationDto dto)
        => Ok(await _service.CreateAsync(dto));

    [HttpDelete("id")]
    public async Task<IActionResult> Delete(long id)
        => Ok(await _service.RemoveAsync(id));

    [HttpPut]
    public async Task<IActionResult> Update(CommentForUpdateDto dto)
        => Ok(await _service.UpdateAsync(dto));
}
