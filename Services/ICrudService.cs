namespace UserNotebook;

public interface ICrudService<T, Dto>
{
    public IEnumerable<Dto> FindAll();
    public Dto Find(Guid id);
    public void Save(Dto dto);
    public void Update(Dto dto);
    public void Delete(Guid id);
}