using System.ComponentModel.DataAnnotations;
using UserNotebook.Annotations;
using UserNotebook.Dtos;
using UserNotebook.Types;

namespace UserNotebook.Models;

public class AdultDto : UserDto
{
    [Required]
    public bool IsEmployed { get; set; }
    public String CompanyName { get; set; }
    
    public double Salary { get; set; }
    [GreaterThenZeroValidator(Maximum: double.MaxValue, ErrorMessage = "Value must be greater then 0")]
    public double Salary { get; set; }

    public AdultDto(Guid id, string name, string surname, DateOnly birthDay, Sex sex, bool isEmployed, string companyName, double salary)
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
