using System.ComponentModel.DataAnnotations;
using UserNotebook.Annotations;
using UserNotebook.Types;

namespace UserNotebook.Dtos;

public class UserDto
{
    public Guid Id { get; set; }

    [Required]
    [StringLength(50, ErrorMessage = "Name is too long (max 50 chars)")]
    public string Name { get; set; }

    [Required]
    [StringLength(150, ErrorMessage = "Surname is too long (max 150 chars)")]
    public string Surname { get; set; }

    [Required]
    [BirthdayValidator(ErrorMessage = "Date cannot be from the future")]
    public DateOnly Birthday { get; set; }

    [Required] public Sex Sex { get; set; }

    public string Discriminator { get; set; }
}