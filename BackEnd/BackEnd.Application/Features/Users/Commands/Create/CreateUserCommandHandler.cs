using AutoMapper;
using MediatR;
using BackEnd.Application.Interfaces;
using BackEnd.Application.Interfaces.Repositories;
using BackEnd.Application.DTOs.Users;

namespace BackEnd.Application.Features.Users.Commands.Create;

public class CreateUserCommandHandler
    : IRequestHandler<CreateUserCommand, ResponseUserDto>
{
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreateUserCommandHandler(
        IUserRepository userRepository,
        IUnitOfWork unitOfWork,
        IMapper mapper)
    {
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<ResponseUserDto> Handle(
        CreateUserCommand request,
        CancellationToken cancellationToken)
    {
        var user = _mapper.Map<Domain.Entities.User>(request);

        await _userRepository.AddAsync(user, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        var result = _mapper.Map<ResponseUserDto>(user);
        return result;
    }
}


