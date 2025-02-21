using Dapper;
using demo.Core.Common;
using demo.Core.Data;
using demo.Core.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo.Infra.Repository
{
    public class CourseRepository : ICourseRepository
    {
        private readonly IDbContext _dbConext;

        public CourseRepository(IDbContext dbConext)
        {

            _dbConext = dbConext;

        }
        public List<Course> GeiAllCourses()
        {
            IEnumerable<Course> result = _dbConext.Connection.Query<Course>
                ("course_package.GetAllCourses", commandType: CommandType.StoredProcedure);

            return result.ToList();
        }
        public void CreateCourse(Course course)
        {
            var p = new DynamicParameters();
            p.Add("course_name", course.Coursename, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("image_name", course.Imagename, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("category_id", course.Categoryid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = _dbConext.Connection.Execute("course_package.createcourse", p, commandType: CommandType.StoredProcedure);
        }

        public void DeleteCourse(int id)
        {
            var p = new DynamicParameters();
            p.Add("course_id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = _dbConext.Connection.Execute("course_package.deletecourse", p, commandType: CommandType.StoredProcedure);

        }



        public Course GetCourseById(int id)
        {
            var p = new DynamicParameters();
            p.Add("course_id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            IEnumerable<Course> result = _dbConext.Connection.Query<Course>
                ("course_package.getcoursebyid", p, commandType: CommandType.StoredProcedure);

            return result.FirstOrDefault();
        }

        public void UpdateCourse(Course course)
        {
            var p = new DynamicParameters();
            p.Add("course_id", course.Courseid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("course_name", course.Coursename, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("image_name", course.Imagename, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("category_id", course.Categoryid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = _dbConext.Connection.Execute("course_package.updatecourse", p, commandType: CommandType.StoredProcedure);
        }
    }
}
