using UserNotebook.Annotations;
using UserNotebook.Dtos;
using UserNotebook.Types;

namespace UserNotebook.Models;

public class KidDto : UserDto
{
    public KidDto(Guid id, string name, string surname, DateOnly birthday, Sex sex, double bagWeight, string schoolName)
    {
        Id = id;
        Name = name;
        Surname = surname;
        Birthday = birthday;
        Sex = sex;
        BagWeight = bagWeight;
        SchoolName = schoolName;
    }

    [GreaterThenZeroValidator(10, ErrorMessage = "Bag weight must be between 0 and 10")]
    public double BagWeight { get; set; }

    public string SchoolName { get; set; }
}