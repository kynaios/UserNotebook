using UserNotebook.Dtos;

namespace UserNotebook;

public interface IRaportService
{
    public IEnumerable<RaportDto> FindAll();
}