using AutoMapper;
using BackEnd.API.Models.Requests.Users;
using BackEnd.API.Models.Responses.Users;
using BackEnd.Application.DTOs.Users;
using BackEnd.Application.Features.Users.Commands.Create;
using BackEnd.Domain.Entities;

namespace BackEnd.API.Mappings;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<CreateUserRequest, CreateUserDto>();
        CreateMap<CreateUserDto, User>();
        CreateMap<User, ResponseUserDto>();
        CreateMap<ResponseUserDto, UserResponse>();
        CreateMap<CreateUserCommand, User>();
    }
}
