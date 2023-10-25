using AutoMapper;
using UserNotebook.Context;
using UserNotebook.Dtos;
using UserNotebook.Models;


namespace UserNotebook;

public class ReportService : IReportService
{
    private readonly IReportRepository _repository;
    private readonly IMapper _mapper;

    public ReportService(IReportRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public IEnumerable<ReportDto> FindAll()
    {
        var reports = _repository.FindAll();
        
        return _mapper.Map<IEnumerable<Report>, IEnumerable<ReportDto>>(reports);
    }
}