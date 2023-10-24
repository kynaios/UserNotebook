using UserNotebook.Types;

namespace UserNotebook.Dtos;

public class UserDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public DateOnly BirthDay { get; set; }
    public Sex Sex { get; set; }
}