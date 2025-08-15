using Assignment_3.Data.Entities;
using Assignment_3.Data.Repositories.Interfaces;
using Assignment_3.Services.Interfaces;
using Humanizer;

namespace Assignment_3.Services.Implementations
{
    public class StudentService : IStudentService
    {
        private readonly IUnitOfWork _unitOfWork;

        public StudentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<Student> GetStudentsAboveAge(int age)
        {
            return _unitOfWork.Students.GetStudentsAboveAge(age);
        }

        public IEnumerable<Student> SearchStudents(string query)
        {
            return _unitOfWork.Students.SearchByName(query);
        }

        public int GetStudentCountAboveAge(int age)
        {
            return _unitOfWork.Students.GetStudentCountAboveAge(age);
        }

        public Student? GetStudentById(int id)
        {
            return _unitOfWork.Students.GetById(id);
        }

        public bool EmailExists(string email, int? excludeId = null)
        {
            return _unitOfWork.Students.EmailExists(email, excludeId);
        }

        public void CreateStudent(Student student)
        {
            if (EmailExists(student.Email))
                throw new Exception("Email already exists.");

            _unitOfWork.Students.Add(student);
            _unitOfWork.Complete();
        }

        public void UpdateStudent(Student student)
        {
            if (EmailExists(student.Email, student.Id))
                throw new Exception("Email already exists.");

            _unitOfWork.Students.Update(student);
            _unitOfWork.Complete();
        }

        public void DeleteStudent(int id)
        {
            var student = _unitOfWork.Students.GetById(id);
            if (student != null)
            {
                _unitOfWork.Students.Delete(student);
                _unitOfWork.Complete();
            }
        }
    }
}
