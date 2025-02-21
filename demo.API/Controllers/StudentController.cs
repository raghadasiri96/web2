using demo.Core.Data;
using demo.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace demo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService studentService;

        public StudentController(IStudentService studentService)
        {
            this.studentService = studentService;
        }

        [HttpGet]
        public List<Student> GetAllStudent()
        {
            return studentService.GeiAllStudent();
        }
        [HttpGet]
        [Route("getbyId/{id}")]
        public Student GetStudentById(int id)
        {

            return studentService.GetStdStudentById(id);
        }

        [HttpPost]
        public void CreateStudent(Student student)
        {
            studentService.CreateStudent(student);
        }
        [HttpPut]
        public void UpdateStudent(Student student)
        {
            studentService.CreateStudent(student);
        }

        [HttpDelete]
        [Route("DeleteStudent/{id}")]
        public void DeleteStudent(int id)
        {
            studentService.DeleteStudent(id);
        }
        [HttpGet]
        [Route("GetStudentBetweenInterval/{datefrom}/{dateto}")]
        public List<Student> GetStudentBetweenInterval(DateTime datefrom, DateTime  dateto)
        {
            return studentService.GetStudentBetweenInterval(datefrom, dateto);
        }
        [HttpGet]
        [Route("GetStudentByBirthDate/{date}")]
        public List<Student> GetStudentByBirthDate(DateTime date)
        {
            return studentService.GetStudentByBirthDate(date);
        }
        [HttpGet]
        [Route("GetStudentByFirstName/{firstName}")]
        public List<Student> GetStudentByFirstName(string firstName)
        {
            return studentService.GetStudentByFirstName(firstName);
        }
        [HttpGet]
        [Route("GetStudentFNameAndLName")]
        public List<Student> GetStudentFNameAndLName()
        {
            return studentService.GetStudentFNameAndLName();
        }
    }
}
