using demo.Core.Data;
using demo.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace demo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StdCourseController : ControllerBase
    {
        private readonly IStdCourseService stdCourseService;

        public StdCourseController(IStdCourseService stdCourseService)
        {
            this.stdCourseService = stdCourseService;
        }

        [HttpGet]
        public List<Stdcourse> GetAllstdCourse()
        {
            return stdCourseService.GeiAllStdcourse();
        }
        [HttpGet]
        [Route("getbyId/{id}")]
        public Stdcourse GetStdcourseById(int id)
        {

            return stdCourseService.GetStdcourseById(id);
        }

        [HttpPost]
        public void CreateStdcourse(Stdcourse stdcourse)
        {
            stdCourseService.CreateStdcourse(stdcourse);
        }
        [HttpPut]
        public void UpdateStdcourse(Stdcourse stdcourse)
        {
            stdCourseService.CreateStdcourse(stdcourse);
        }

        [HttpDelete]
        [Route("DeleteStdcourse/{id}")]
        public void DeleteStdcourse(int id)
        {
            stdCourseService.DeleteStdcourse(id);
        }

    }
}
