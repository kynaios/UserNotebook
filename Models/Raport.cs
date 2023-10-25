using System.ComponentModel.DataAnnotations.Schema;

namespace UserNotebook.Models;

public class Report
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public DateOnly Birthday { get; set; }
    
    [Column("sex_name")]
    public string Sex_Name { get; set; }
    
    [Column("title")]
    public string Title { get; set; }
    
    [Column("age")]
    public int Age { get; set; }
}