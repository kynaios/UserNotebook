using UserNotebook.Types;

namespace UserNotebook.Models;

public interface IUser
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public DateOnly BirthDay { get; set; }
    public Sex Sex { get; set; }
}