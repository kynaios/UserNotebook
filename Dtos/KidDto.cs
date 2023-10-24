using UserNotebook.Dtos;
using UserNotebook.Types;

namespace UserNotebook.Models;

public class KidDto : UserDto
{
    public double BagWeight { get; set; }
    public String SchoolName { get; set; }
    
    public KidDto(Guid id, string name, string surname, DateOnly birthDay, Sex sex, double bagWeight, string schoolName)
    {
        Id = id;
        Name = name;
        Surname = surname;
        BirthDay = birthDay;
        Sex = sex;
        BagWeight = bagWeight;
        SchoolName = schoolName;
    }
}