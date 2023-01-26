public interface IService<T>
{
    T Create(T entity);
    T Read(int id);
    T Update(T entity);
    void Delete(T entity);
    // other business logic methods
}