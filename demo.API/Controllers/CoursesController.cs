using demo.Core.Data;
using demo.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace demo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly ICourseService courseService;

        public CoursesController(ICourseService courseService)
        {
            this.courseService = courseService;
        }

        [HttpGet]
        public List<Course> GetAllCourses()
        {
            return courseService.GeiAllCourses();
        }
        [HttpGet]
        [Route("getbyId/{id}")]
        public Course GetCourseById(int id)
        {

            return courseService.GetCourseById(id);
        }

        [HttpPost]
        public void CreateCourse(Course course)
        {
            courseService.CreateCourse(course);
        }
        [HttpPut]
        public void UpdateCourse(Course course)
        {
            courseService.UpdateCourse(course);
        }

        [HttpDelete]
        [Route("DeleteCourse/{id}")]
        public void DeleteCourse(int id)
        {
            courseService.DeleteCourse(id);
        }
    }
}
