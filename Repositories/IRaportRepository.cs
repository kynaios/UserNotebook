using UserNotebook.Models;

namespace UserNotebook;

public interface IRaportRepository
{
    public IEnumerable<Raport> FindAll();
}