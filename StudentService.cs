public class StudentService : Service<Student>, IStudentService
{
    public StudentService(IStudentRepository studentRepository, IUnitOfWork unitOfWork) : base(studentRepository, unitOfWork) { }

    public IEnumerable<Student> GetStudentsByName(string name)
    {
        return _repository.GetStudentsByName(name);
    }
}