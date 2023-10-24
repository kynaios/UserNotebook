using System.ComponentModel.DataAnnotations;
using UserNotebook.Types;

namespace UserNotebook.Dtos;

public class UserDto
{
    public Guid Id { get; set; }
    
    [Required]
    [StringLength(maximumLength: 50, ErrorMessage = "Name is too long (max 50 chars)")]
    public string Name { get; set; }
    
    [Required]
    [StringLength(maximumLength: 150, ErrorMessage = "Surname is too long (max 150 chars)")]
    public string Surname { get; set; }
    
    [Required]
    public DateOnly BirthDay { get; set; }
    
    [Required]
    public Sex Sex { get; set; }
    
    public String Discriminator { get; set; }
}