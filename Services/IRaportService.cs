using UserNotebook.Dtos;

namespace UserNotebook;

public interface IReportService
{
    public IEnumerable<ReportDto> FindAll();
}