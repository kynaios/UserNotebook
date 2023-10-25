

using UserNotebook.Context;
using UserNotebook.Models;

namespace UserNotebook;

public class RaportRepository : IRaportRepository
{
    private readonly UserContext _context;

    public RaportRepository(UserContext context)
    {
        _context = context;
    }

    public IEnumerable<Raport> FindAll()
    {
        return _context.Raports.AsEnumerable();
    }
}