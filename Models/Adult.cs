using UserNotebook.Types;

namespace UserNotebook.Models;

public class Adult : User
{
    public bool IsEmployed { get; set; }
    public string CompanyName { get; set; }
    public double Salary { get; set; }
}