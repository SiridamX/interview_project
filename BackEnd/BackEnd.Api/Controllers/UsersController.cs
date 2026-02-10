using MediatR;
using Microsoft.AspNetCore.Mvc;
using BackEnd.Application.Features.Users.Commands.Create;
using BackEnd.Application.Features.Users.Queries;

namespace BackEnd.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly IMediator _mediator;

    public UsersController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateUserCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpGet()]
    public async Task<IActionResult> GetAll()
    {
        var user = await _mediator.Send(new GetAllUsersQuery());
        if (user == null) return NotFound();
        return Ok(user);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var user = await _mediator.Send(new GetUserByIdQuery(id));
        if (user == null) return NotFound();
        return Ok(user);
    }
}


