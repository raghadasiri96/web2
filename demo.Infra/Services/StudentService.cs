using demo.Core.Data;
using demo.Core.Repository;
using demo.Core.Services;
using demo.Infra.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo.Infra.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;

        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }
        public void CreateStudent(Student student)
        {
            _studentRepository.CreateStudent(student);
        }

        public void DeleteStudent(int id)
        {
            _studentRepository.DeleteStudent(id);
        }

        public List<Student> GeiAllStudent()
        {
            return _studentRepository.GeiAllStudent();
        }
        public void UpdateStudent(Student student)
        {
            _studentRepository.UpdateStudent(student);
        }
        public Student GetStdStudentById(int id)
        {
            return _studentRepository.GetStdStudentById(id);
        }

        public List<Student> GetStudentBetweenInterval(DateTime datefrom, DateTime dateto)
        {
            return _studentRepository.GetStudentBetweenInterval(datefrom, dateto);
        }

        public List<Student> GetStudentByBirthDate(DateTime date)
        {
            return _studentRepository.GetStudentByBirthDate(date);
        }

        public List<Student> GetStudentByFirstName(string firstName)
        {
            return _studentRepository.GetStudentByFirstName(firstName);
        }

        public List<Student> GetStudentFNameAndLName()
        {
            return _studentRepository.GetStudentFNameAndLName();
        }

    }
}
