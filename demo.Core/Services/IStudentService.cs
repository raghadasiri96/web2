using demo.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo.Core.Services
{
    public interface IStudentService
    {
        List<Student> GeiAllStudent();
        void CreateStudent(Student student);
        void UpdateStudent(Student student);
        void DeleteStudent(int id);
        Student GetStdStudentById(int id);
        List<Student> GetStudentByFirstName(string firstName);
        List<Student> GetStudentByBirthDate(DateTime date);
        List<Student> GetStudentFNameAndLName();
        List<Student> GetStudentBetweenInterval(DateTime datefrom, DateTime dateto);
    }
}
