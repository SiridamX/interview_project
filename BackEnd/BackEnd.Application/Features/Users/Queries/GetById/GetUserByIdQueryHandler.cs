using MediatR;
using AutoMapper;
using BackEnd.Application.DTOs.Users;
using BackEnd.Application.Interfaces;

namespace BackEnd.Application.Features.Users.Queries;

public class GetUserByIdQueryHandler
    : IRequestHandler<GetUserByIdQuery, ResponseUserDto?>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetUserByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<ResponseUserDto?> Handle(
        GetUserByIdQuery request,
        CancellationToken cancellationToken)
    {
        var user = await _unitOfWork.Users
            .GetByIdAsync(request.Id, cancellationToken);

        if (user == null)
            return null;

        return _mapper.Map<ResponseUserDto>(user);
    }
}
