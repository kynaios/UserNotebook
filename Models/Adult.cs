using UserNotebook.Types;

namespace UserNotebook.Models;

public class Adult : User
{
    public bool IsEmployed { get; set; }
    public string CompanyName { get; set; }
    public float Salary { get; set; }
}