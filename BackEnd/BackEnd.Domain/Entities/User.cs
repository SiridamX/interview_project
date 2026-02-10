using BackEnd.Domain.Common;
using BackEnd.Domain.Events;

namespace BackEnd.Domain.Entities;

public class User : BaseEntity
{
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public string Address { get; set; } = default!;
    public DateOnly BirthOfDate { get; set; } = default!;
    public int Age
    {
        get
        {
            var today = DateOnly.FromDateTime(DateTime.Today);
            var age = today.Year - BirthOfDate.Year;

            if (BirthOfDate.AddYears(age) > today)
                age--;

            return Math.Max(age, 0);
        }
    }


    public void RaiseCreatedEvent()
    {
        var @event = new UserCreatedEvent(this);
        AddDomainEvent(@event);
    }
}
