public class Service<T> : IService<T>
{
    private readonly IRepository<T> _repository;
    private readonly IUnitOfWork _unitOfWork;

    public Service(IRepository<T> repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public T Create(T entity)
    {
        _repository.Create(entity);
        _unitOfWork.SaveChanges();
        return entity;
    }

    public T Read(int id)
    {
        return _repository.Read(id);
    }

    public T Update(T entity)
    {
        _repository.Update(entity);
        _unitOfWork.SaveChanges();
        return entity;
    }

    public void Delete(T entity)
    {
        _repository.Delete(entity);
        _unitOfWork.SaveChanges();
    }
}

public class Service<T> : IService<T> where T : class, IValidatableObject
{
    private readonly IUnitOfWork _unitOfWork;

    public Service(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public T Create(T entity)
    {
        Validate(entity);
        _unitOfWork.Repository<T>().Create(entity);
        _unitOfWork.SaveChanges();
        return entity;
    }

    public T Update(T entity)
    {
        Validate(entity);
        _unitOfWork.Repository<T>().Update(entity);
        _unitOfWork.SaveChanges();
        return entity;
    }

    private void Validate(T entity)
    {
        var validationContext = new ValidationContext(entity);
        var validationResults = new List<ValidationResult>();
        if (!Validator.TryValidateObject(entity, validationContext, validationResults, true))
        {
            throw new ValidationException(validationResults);
        }
    }
    //...
}&