namespace BackEnd.API.Models.Responses.Users;

public class UserResponse
{
    public int Id { get; set; }
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public string Age { get; set; } = default!;
    public string BirthOfDate { get; set; } = default!;

}
