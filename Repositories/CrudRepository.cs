using Microsoft.EntityFrameworkCore;
using UserNotebook.Context;
using UserNotebook.Models;

namespace UserNotebook;

public class CrudRepository<TUser> : ICrudRepository<TUser> where TUser : User
{
    private readonly UserContext _context;
    private DbSet<TUser> entities;

    public CrudRepository(UserContext context)
    {
        _context = context;
        entities = context.Set<TUser>();
    }

    public IEnumerable<TUser> FindAll()
    {
        return entities.AsEnumerable();
    }

    public TUser Find(Guid id)
    {
        return entities.SingleOrDefault(x=>x.Id==id);
    }

    public void Save(TUser dto)
    {
        entities.Add(dto);
        _context.SaveChanges();
    }

    public void Update(TUser dto)
    {
        entities.Update(dto);
        _context.SaveChanges();
    }

    public void Delete(Guid id)
    {
        var enity = entities.Find(id);
        entities.Remove(enity);
    }
}