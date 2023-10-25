using AutoMapper;
using UserNotebook.Dtos;
using UserNotebook.Models;

namespace UserNotebook.Mappers;

public class MapperProfile : Profile
{
    public MapperProfile()
    {
        // Adult
        CreateMap<Adult, AdultDto>();
        CreateMap<AdultDto, Adult>();

        // Kid
        CreateMap<Kid, KidDto>();
        CreateMap<KidDto, Kid>();

        // Reports
        CreateMap<Report, ReportDto>();
        CreateMap<ReportDto, Report>();
    }
}