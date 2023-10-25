namespace UserNotebook.Dtos;

public class ReportDto
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public DateOnly Birthday { get; set; }
    public string Sex_Name { get; set; }
    public string Title { get; set; }
    public int Age { get; set; }
}