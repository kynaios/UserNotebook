using AutoMapper;
using UserNotebook.Context;
using UserNotebook.Dtos;
using UserNotebook.Models;


namespace UserNotebook;

public class RaportService : IRaportService
{
    private readonly IRaportRepository _repository;
    private readonly IMapper _mapper;

    public RaportService(IRaportRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public IEnumerable<RaportDto> FindAll()
    {
        var raports = _repository.FindAll();
        
        return _mapper.Map<IEnumerable<Raport>, IEnumerable<RaportDto>>(raports);
    }
}