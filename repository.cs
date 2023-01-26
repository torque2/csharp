public class Repository<T> : IRepository<T> where T : class
{
    private readonly DbContext _context;
    private readonly DbSet<T> _dbSet;

    public Repository(DbContext context)
    {
        _context = context;
        _dbSet = context.Set<T>();
    }

    public T Create(T entity)
    {
        _dbSet.Add(entity);
        return entity;
    }

    public T Read(int id)
    {
        return _dbSet.Find(id);
    }

    public T Update(T entity)
    {
        _context.Entry(entity).State = Entity.EntityState.Modified;
        return entity;
    }

    public void Delete(T entity)
    {
        _dbSet.Remove(entity);
    }
}