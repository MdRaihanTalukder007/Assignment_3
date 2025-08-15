using Assignment_3.Data.Entities;
using Assignment_3.Data.Repositories.Interfaces;

namespace Assignment_3.Data.Repositories.Implementations
{
    public class StudentRepository : IStudentRepository
    {
        private readonly ApplicationDbContext _context;

        public StudentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Student> GetStudentsAboveAge(int age)
        {
            return _context.Students.Where(s => s.Age > age).ToList();
        }

        public IEnumerable<Student> SearchByName(string query)
        {
            return _context.Students
                .Where(s => s.FirstName.Contains(query) || s.LastName.Contains(query))
                .ToList();
        }

        public int GetStudentCountAboveAge(int age)
        {
            return _context.Students.Count(s => s.Age > age);
        }

        public Student? GetById(int id)
        {
            return _context.Students.FirstOrDefault(s => s.Id == id);
        }

        public void Add(Student student)
        {
            _context.Students.Add(student);
        }

        public void Update(Student student)
        {
            _context.Students.Update(student);
        }

        public void Delete(Student student)
        {
            _context.Students.Remove(student);
        }
    }
}