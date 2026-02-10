using MediatR;
using BackEnd.Application.DTOs.Users;

namespace BackEnd.Application.Features.Users.Queries;

public record GetUserByIdQuery(int Id)
    : IRequest<ResponseUserDto>;
