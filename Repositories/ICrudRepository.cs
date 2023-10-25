namespace UserNotebook;

public interface ICrudRepository<T>
{
    public IEnumerable<T> FindAll();
    public T Find(Guid id);
    public void Save(T dto);
    public void Update(T dto);
    public void Delete(Guid id);
}