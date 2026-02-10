namespace BackEnd.API.Models.Requests.Users;

public class CreateUserRequest
{
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;

    public string Address { get; set; } = default!;

    public DateOnly BirthOfDate { get; set; }
}
