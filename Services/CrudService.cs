using AutoMapper;
using UserNotebook.Dtos;
using UserNotebook.Models;

namespace UserNotebook;

public class CrudService<TUser, Dto> : ICrudService<TUser, Dto> where TUser : User
{
    private readonly ICrudRepository<TUser> _repository;
    private readonly IMapper _mapper;

    public CrudService(ICrudRepository<TUser> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public IEnumerable<Dto> FindAll()
    {
        var entities = _repository.FindAll();
        var dtos = _mapper.Map<IEnumerable<TUser>, IEnumerable<Dto>>(entities);
        return dtos;
    }

    public Dto Find(Guid id)
    {
        var entity = _repository.Find(id);
        var dto = _mapper.Map<TUser, Dto>(entity);
        return dto;
    }

    public void Save(Dto dto)
    {
        var entity = _mapper.Map<Dto, TUser>(dto);
        _repository.Save(entity);
    }

    public void Update(Dto dto)
    {
        var entity = _mapper.Map<Dto, TUser>(dto);
        _repository.Update(entity);
    }

    public void Delete(Guid id)
    {
        _repository.Delete(id);
    }
}