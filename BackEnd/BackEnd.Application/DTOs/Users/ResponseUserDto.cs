namespace BackEnd.Application.DTOs.Users;

public class ResponseUserDto
{
    public int Id { get; set; }

    public string FirstName { get; set; } = default!;

    public string LastName { get; set; } = default!;

    public string Address { get; set; } = default!;

    public DateOnly BirthOfDate { get; set; }

    public int Age { get; set; }
}
