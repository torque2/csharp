public class UnitOfWork<T> : IUnitOfWork where T : class
{
    private readonly DbContext _context;
    private IRepository<T> _repository;

    public UnitOfWork(DbContext context)
    {
        _context = context;
    }

    public IRepository<T> Repository
    {
        get
        {
            if (_repository == null)
            {
                _repository = new Repository<T>(_context);
            }

            return _repository;
        }
    }

    public void SaveChanges()
    {
        _context.SaveChanges();
    }
}