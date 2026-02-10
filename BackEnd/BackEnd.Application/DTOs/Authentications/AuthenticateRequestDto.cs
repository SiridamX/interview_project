namespace BackEnd.Application.DTOs.Authentications;

public class AuthenticateRequestDto
{
    public string Email { get; set; } = default!;
    public string Password { get; set; } = default!;
}
