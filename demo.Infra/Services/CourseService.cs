using demo.Core.Data;
using demo.Core.Repository;
using demo.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo.Infra.Services
{
    
        public class CourseService : Core.Services.ICourseService
        {
            private readonly ICourseRepository _courseRepository;

            public CourseService(ICourseRepository courseRepository)
            {
                _courseRepository = courseRepository;
            }

            public void CreateCourse(Course course)
            {
                _courseRepository.CreateCourse(course);
            }

            public void DeleteCourse(int id)
            {
                _courseRepository.DeleteCourse(id);
            }

            public List<Course> GeiAllCourses()
            {
                return _courseRepository.GeiAllCourses();
            }

            public Course GetCourseById(int id)
            {
                return _courseRepository.GetCourseById(id);
            }

            public void UpdateCourse(Course course)
            {
                _courseRepository.UpdateCourse(course);
            }
        }
 }

