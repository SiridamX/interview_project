namespace BackEnd.Application.DTOs.Authentications;

public class AuthenticateResponseDto
{
    public string Token { get; set; } = default!;
    public string UserName { get; set; } = default!;
}
