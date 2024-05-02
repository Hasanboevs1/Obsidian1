using Microsoft.AspNetCore.Mvc;
using Obsidian.Service.DTOs.Users;
using Obsidian.Service.IServices;

namespace Obsidian.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly IUserService _service;

    public UsersController(IUserService service)
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
    public async Task<IActionResult> Create(UserForCreationDto dto)
        => Ok(await _service.CreateAsync(dto));

    [HttpDelete("id")]
    public async Task<IActionResult> Delete(long id)
        => Ok(await _service.RemoveAsync(id));

    [HttpPut]
    public async Task<IActionResult> Update(UserForUpdateDto dto)
        => Ok(await _service.UpdateAsync(dto));

}
