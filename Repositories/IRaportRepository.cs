using UserNotebook.Models;

namespace UserNotebook;

public interface IReportRepository
{
    public IEnumerable<Report> FindAll();
}