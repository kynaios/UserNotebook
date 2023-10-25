namespace UserNotebook.Dtos;

public class RaportDto
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public DateOnly BirthDay { get; set; }
    public string Sex_Name { get; set; }
    public string Title { get; set; }
    public int Age { get; set; }
}