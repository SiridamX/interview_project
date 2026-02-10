namespace BackEnd.Application.DTOs.Users;

public class CreateUserDto
{
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;

    public string Email { get; set; } = default!;

    public string Address { get; set; } = default!;

    public DateOnly BirthOfDate { get; set; }
}
