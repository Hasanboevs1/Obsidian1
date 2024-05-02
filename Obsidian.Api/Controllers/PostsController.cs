using Microsoft.AspNetCore.Mvc;
using Obsidian.Service.DTOs.Posts;
using Obsidian.Service.IServices;

namespace Obsidian.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PostsController : ControllerBase
{
    private readonly IPostService _service;

    public PostsController(IPostService service)
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
    public async Task<IActionResult> Create(PostForCreationDto dto)
        => Ok(await _service.CreateAsync(dto));

    [HttpDelete("id")]
    public async Task<IActionResult> Delete(long id)
        => Ok(await _service.DeleteAsync(id));

    [HttpPut]
    public async Task<IActionResult> Update(PostForUpdateDto dto)
        => Ok(await _service.UpdateAsync(dto));
}
