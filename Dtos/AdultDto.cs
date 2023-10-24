using System.ComponentModel.DataAnnotations;
using UserNotebook.Dtos;
using UserNotebook.Types;

namespace UserNotebook.Models;

public class AdultDto : UserDto
{
    [Required]
    public bool IsEmployed { get; set; }
    public String CompanyName { get; set; }
    public float Salary { get; set; }

    public AdultDto(Guid id, string name, string surname, DateOnly birthDay, Sex sex, bool isEmployed, string companyName, float salary)
    {
        Id = id;
        Name = name;
        Surname = surname;
        BirthDay = birthDay;
        Sex = sex;
        IsEmployed = isEmployed;
        CompanyName = companyName;
        Salary = salary;
    }
}