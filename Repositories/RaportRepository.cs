using UserNotebook.Context;
using UserNotebook.Models;

namespace UserNotebook;

public class ReportRepository : IReportRepository
{
    private readonly UserContext _context;

    public ReportRepository(UserContext context)
    {
        _context = context;
    }

    public IEnumerable<Report> FindAll()
    {
        return _context.Reports.AsEnumerable();
    }
}