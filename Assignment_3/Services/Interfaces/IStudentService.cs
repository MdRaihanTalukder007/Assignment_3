using Assignment_3.Data.Entities;

namespace Assignment_3.Services.Interfaces
{
    public interface IStudentService
    {
        IEnumerable<Student> GetStudentsAboveAge(int age);
        IEnumerable<Student> SearchStudents(string query);
        int GetStudentCountAboveAge(int age);
        Student? GetStudentById(int id);
        void CreateStudent(Student student);
        void UpdateStudent(Student student);
        void DeleteStudent(int id);
    }
}
