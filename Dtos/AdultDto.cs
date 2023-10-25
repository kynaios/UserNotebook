using System.ComponentModel.DataAnnotations;
using UserNotebook.Annotations;
using UserNotebook.Dtos;
using UserNotebook.Types;

namespace UserNotebook.Models;

public class AdultDto : UserDto
{
    public AdultDto(Guid id, string name, string surname, DateOnly birthday, Sex sex, bool isEmployed,
        string companyName, double salary)
    {
        Id = id;
        Name = name;
        Surname = surname;
        Birthday = birthday;
        Sex = sex;
        IsEmployed = isEmployed;
        CompanyName = companyName;
        Salary = salary;
    }

    [Required] public bool IsEmployed { get; set; }
    public string CompanyName { get; set; }

    [GreaterThenZeroValidator(double.MaxValue, ErrorMessage = "Value must be greater then 0")]
    public double Salary { get; set; }
}