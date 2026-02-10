using BackEnd.Domain.Entities;

namespace BackEnd.Application.Interfaces.Security;

public interface ITokenService
{
    string GenerateToken(User user);
    int GetUserFromToken(string token);
}
