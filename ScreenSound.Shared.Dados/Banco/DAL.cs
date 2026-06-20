using Microsoft.EntityFrameworkCore;

namespace ScreenSound.Data;

public class DAL<T> where T : class
{
    private readonly ScreenSoundContext _context;

    public DAL(ScreenSoundContext context)
    {
        _context = context;
    }

    public IEnumerable<T> GetAll()
    {
        return _context.Set<T>().ToList();
    }

    public IEnumerable<T> GetAll(string propertyPath)
    {
        return _context.Set<T>().Include(propertyPath).ToList();
    }

    public void Add(T entity)
    {
        _context.Set<T>().Add(entity);
        _context.SaveChanges();
    }

    public void Update(T entity)
    {
        _context.Set<T>().Update(entity);
        _context.SaveChanges();
    }

    public void Delete(T entity)
    {
        _context.Set<T>().Remove(entity);
        _context.SaveChanges();
    }

    public T? GetBy(Func<T, bool> condition)
    {
        return _context.Set<T>().FirstOrDefault(condition);
    }
}
