using Assignment_3.Data.Entities;

namespace Assignment_3.Data.Repositories.Interfaces
{
    public interface IStudentRepository
    {
        IEnumerable<Student> GetStudentsAboveAge(int age);
        IEnumerable<Student> SearchByName(string query);
        int GetStudentCountAboveAge(int age);
        void Add(Student student);
        Student? GetById(int id);
        void Update(Student student);
        void Delete(Student student);
        bool EmailExists(string email, int? excludeId = null);
    }
}
