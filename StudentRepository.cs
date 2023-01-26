public class StudentRepository : Repository<Student>, IStudentRepository
{
    public StudentRepository(DbContext context) : base(context) { }

    public IEnumerable<Student> GetStudentsByName(string name)
    {
        return _dbSet.Where(s => s.Name == name).ToList();
    }
}