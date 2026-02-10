using BackEnd.Application.DTOs.Users;
using MediatR;

namespace BackEnd.Application.Features.Users.Commands.Create;

public class CreateUserCommand : IRequest<ResponseUserDto>
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public string Address { get; set; } = string.Empty;

    public DateOnly BirthOfDate { get; set; }
}
