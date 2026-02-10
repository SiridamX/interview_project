using AutoMapper;
using MediatR;
using BackEnd.Application.DTOs.Users;
using BackEnd.Application.Interfaces.Repositories;

namespace BackEnd.Application.Features.Users.Queries;

public class GetAllUsersQueryHandler
    : IRequestHandler<GetAllUsersQuery, IReadOnlyList<ResponseUserDto>>
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public GetAllUsersQueryHandler(
        IUserRepository userRepository,
        IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<IReadOnlyList<ResponseUserDto>> Handle(
        GetAllUsersQuery request,
        CancellationToken cancellationToken)
    {
        var users = await _userRepository.GetAllAsync(cancellationToken);

        return _mapper.Map<IReadOnlyList<ResponseUserDto>>(users);
    }
}
