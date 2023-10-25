using UserNotebook.Annotations;
using UserNotebook.Dtos;
using UserNotebook.Types;

namespace UserNotebook.Models;

public class KidDto : UserDto
{
    [GreaterThenZeroValidator(Maximum: 10, ErrorMessage = "Bag weight must be between 0 and 10")]
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